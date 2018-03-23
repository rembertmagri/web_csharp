# C# ASP.NET MVC - Proof of Concept project

## Purpose
> To create an MVC project on Visual Studio to run a simple CRUD web application using:
 * Multitier architecture:
   * Data layer (Entity Framework)
   * Business layer
   * Service  layer (WCF)
   * Presentation layer:
     * Pure MVC
     * MVC + jQuery and DataTables
     * MVC + AngularJS

## Step 1) Solution Structure and Layer division
> mvc wcf entity framework example

    Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

[Calling WCF Services and Entity Framework in ASP.NET MVC Application](https://www.youtube.com/watch?v=H6MzA1KW3o0)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image001.png?raw=true)

> Gutenberg repository (total uncompressed size of all files is about 35GB) consists of several text files (books), each one with some Mbytes. This kind of scenario is not ideal when using HDFS; it would be better to have a small number of larger files. Because of that, the files on each extracted directory were concatenated together using the following command:

    find 1/ -type f -exec cat {} \; > 1_cat.txt
    find 2/ -type f -exec cat {} \; > 2_cat.txt
    find 3/ -type f -exec cat {} \; > 3_cat.txt
    …

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image002.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image003.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image004.png?raw=true)

> Additionally, the smaller files (<100MB) were concatenated together to improve performance.

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image005.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image006.png?raw=true)

## Step 0-1) Cluster creation

> A cluster with 4 machines was created on Azure. 1 of them, ubuntu-server (IP:10.0.0.4), would be the master, another, ubuntu-slave1 (IP:10.0.0.5), would be the secondary node and one of the slaves and the remaining, ubuntu-slave2 (IP:10.0.0.6) and ubuntu-slave3 (IP:10.0.0.7), would be the other slaves.

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image007.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image008.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image009.png?raw=true)

## Step 0-2) Hadoop installation and configuration

> On ubuntu-server, ubuntu-slave1, ubuntu-slave2 and ubuntu-slave3:

    sudo apt-get update
    sudo apt-get install default-jdk
    java -version
    sudo apt-get install ssh
    sudo ufw disable
    readlink -f /usr/bin/java | sed "s:bin/java::"

> Add Hadoop user:

    sudo addgroup hadoop
    sudo adduser --ingroup hadoop hadoop
    sudo adduser hadoop sudo
    su - hadoop

    ssh-keygen -t rsa -P ""
    cat $HOME/.ssh/id_rsa.pub >> $HOME/.ssh/authorized_keys
    vi ~/.bashrc

    ...
    #HADOOP VARIABLES START
    export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64
    export HADOOP_INSTALL=/usr/local/hadoop
    export PATH=$PATH:$HADOOP_INSTALL/bin
    export PATH=$PATH:$HADOOP_INSTALL/sbin
    export HADOOP_MAPRED_HOME=$HADOOP_INSTALL
    export HADOOP_COMMON_HOME=$HADOOP_INSTALL
    export HADOOP_HDFS_HOME=$HADOOP_INSTALL
    export YARN_HOME=$HADOOP_INSTALL
    export HADOOP_COMMON_LIB_NATIVE_DIR=$HADOOP_INSTALL/lib/native
    export HADOOP_OPTS="-Djava.library.path=$HADOOP_INSTALL/lib"
    #HADOOP VARIABLES END

    source ~/.bashrc
    ssh-copy-id 10.0.0.4
    ssh-copy-id 10.0.0.5
    ssh-copy-id 10.0.0.6
    ssh-copy-id 10.0.0.7

> On ubuntu-server only:

> Download and configure Hadoop

    wget http://apache.mirrors.tds.net/hadoop/common/hadoop-2.8.1/hadoop-2.8.1.tar.gz
    tar -xzvf hadoop-2.8.1.tar.gz
    vi hadoop-2.8.1/etc/hadoop/hadoop-env.sh

    …
    export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64
    …

    cd /home/hadoop/hadoop-2.8.1/
    sudo mkdir /usr/local/hadoop
    sudo mv * /usr/local/hadoop
    sudo rm -r hadoop-2.8.1

    vi /usr/local/hadoop/etc/hadoop/core-site.xml

    <configuration>
        <property>
                <name>fs.defaultFS</name>
                <value>hdfs://10.0.0.4:9000</value>
        </property>
        <property>
                <name>hadoop.proxyuser.hadoop.hosts</name>
                <value>*</value>
        </property>
        <property>
                <name>hadoop.proxyuser.hadoop.groups</name>
                <value>*</value>
        </property>
    </configuration>

    vi /usr/local/hadoop/etc/hadoop/hdfs-site.xml

    <configuration>
        <property>
                <name>dfs.namenode.http-address</name>
                <value>10.0.0.4:50070</value>
                <description> fetch NameNode images and edits </description>
        </property>
        <property>
                <name>dfs.namenode.secondary.http-address</name>
                <value>10.0.0.5:50090</value>
                <description> fetch SecondNameNode fsimage </description>
        </property>
        <property>
                <name>dfs.replication</name>
                <value>2</value>
        </property>
        <property>
                <name>dfs.namenode.name.dir</name>
                <value>file:/home/hadoop/work/hadoopdata/dfs/name</value>
        </property>
        <property>
                <name>dfs.datanode.data.dir</name>
                <value>file:/home/hadoop/work/hadoopdata/dfs/data</value>
        </property>
        <property>
                <name>dfs.namenode.checkpoint.dir</name>
                <value>file:/home/hadoop/work/hadoopdata/dfs/namesecondary</value>
        </property>
        <property>
                <name>dfs.webhdfs.enabled</name>
                <value>true</value>
        </property>
        <property>
                <name>dfs.stream-buffer-size</name>
                <value>131072</value>
                <description> buffer </description>
        </property>
        <property>
                <name>dfs.namenode.checkpoint.period</name>
                <value>3600</value>
                <description> duration </description>
        </property>
    </configuration>

    mkdir work
    vi /usr/local/hadoop/etc/hadoop/mapred-env.sh

    export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64

    vi /usr/local/hadoop/etc/hadoop/mapred-site.xml.template

    <configuration>
        <property>
                <name>mapreduce.framework.name</name>
                <value>yarn</value>
        </property>
        <property>
                <name>mapreduce.jobtracker.address</name>
                <value>hdfs://trucy:9001</value>
        </property>
        <property>
                <name>mapreduce.jobhistory.address</name>
                <value>10.0.0.4:10020</value>
                <description>MapReduce JobHistory Server host:port, default port is 10020.</description>
        </property>
        <property>
                <name>mapreduce.jobhistory.webapp.address</name>
                <value>10.0.0.4:19888</value>
                <description>MapReduce JobHistory Server Web UI host:port, default port is 19888.</description>
        </property>
    </configuration>

    cp /usr/local/hadoop/etc/hadoop/mapred-site.xml.template /usr/local/hadoop/etc/hadoop/mapred-site.xml
    vi /usr/local/hadoop/etc/hadoop/yarn-site.xml

    <configuration>
        <property>
                <name>yarn.resourcemanager.hostname</name>
                <value>10.0.0.4</value>
        </property>
        <property>
                <name>yarn.nodemanager.aux-services</name>
                <value>mapreduce_shuffle</value>
        </property>
        <property>
                <name>yarn.nodemanager.aux-services.mapreduce_shuffle.class</name>
                <value>org.apache.hadoop.mapred.ShuffleHandler</value>
        </property>
        <property>
                <name>yarn.resourcemanager.address</name>
                <value>10.0.0.4:8032</value>
        </property>
        <property>
                <name>yarn.resourcemanager.scheduler.address</name>
                <value>10.0.0.4:8030</value>
        </property>
        <property>
                <name>yarn.resourcemanager.resource-tracker.address</name>
                <value>10.0.0.4:8031</value>
        </property>
        <property>
                <name>yarn.resourcemanager.admin.address</name>
                <value>10.0.0.4:8033</value>
        </property>
        <property>
                <name>yarn.resourcemanager.webapp.address</name>
                <value>10.0.0.4:8088</value>
        </property>
    </configuration>

    vi /usr/local/hadoop/etc/hadoop/slaves

    10.0.0.5
    10.0.0.6
    10.0.0.7

    vi /usr/local/hadoop/etc/hadoop/masters

    10.0.0.5

    sudo scp -r /usr/local/hadoop 10.0.0.5:/usr/local
    sudo scp -r /usr/local/hadoop 10.0.0.6:/usr/local
    sudo scp -r /usr/local/hadoop 10.0.0.7:/usr/local

    hdfs namenode -format
    start-dfs.sh
    start-yarn.sh


![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image010.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image011.png?raw=true)

## Step 0-3) Spark configuration

> On ubuntu-server, ubuntu-slave1, ubuntu-slave2 and ubuntu-slave3:

    sudo apt-get install scala
    wget https://d3kbcqa49mib13.cloudfront.net/spark-2.2.0-bin-hadoop2.7.tgz
    tar -xvzf spark-2.2.0-bin-hadoop2.7.tgz
    mv /home/ubuntu/spark-2.2.0-bin-hadoop2.7 /usr/local/spark
    vi ~/.bashrc

    …
    #SPARK VARIABLES START
    export YARN_CONF_DIR=$HADOOP_INSTALL/etc/hadoop
    export SPARK_HOME=/usr/local//spark
    export PATH=$SPARK_HOME/bin:$PATH
    #SPARK VARIABLES END

    cp /usr/local/spark/conf/spark-env.sh.template /usr/local/spark/conf/spark-env.sh
    vi /usr/local/spark/conf/spark-env.sh

    export JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64
    export SPARK_PUBLIC_DNS="10.0.0.4" #or 5, 6, 7
    export SPARK_WORKER_CORES=6

> On ubuntu-server only:

    vi /usr/local/spark/conf/slaves

    10.0.0.5
    10.0.0.6
    10.0.0.7

> Testing Spark cluster configuration:

> On ubuntu-master only:

    $SPARK_HOME/sbin/start-all.sh

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image012.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image013.png?raw=true)

> Testing Spark running on Spark standalone cluster:

> On ubuntu-master only:

    spark-submit --master spark://10.0.0.4:7077 --deploy-mode cluster --class org.apache.spark.examples.JavaSparkPi /usr/local/spark/examples/jars/spark-examples_2.11-2.2.0.jar 100

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image014.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image015.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image016.png?raw=true)

    $SPARK_HOME/sbin/stop-all.sh

> Testing Spark running on YARN:

> On ubuntu-master only:

    spark-submit --master yarn --deploy-mode cluster --class org.apache.spark.examples.JavaSparkPi /usr/local/spark/examples/jars/spark-examples_2.11-2.2.0.jar 100

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image017.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image018.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image019.png?raw=true)

## Step 0-4) Load files into HDFS

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image020.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image021.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image022.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image023.png?raw=true)

## Step 1-1) MapReduce program implementation

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image024.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image025.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image026.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image027.png?raw=true)

    <dependency>
      <groupId>org.apache.hadoop</groupId>
      <artifactId>hadoop-core</artifactId>
      <version>0.20.2</version>
    </dependency>


![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image028.png?raw=true)

    <repositories>
      <repository>
        <id>cloudera</id>
        <url>https://repository.cloudera.com/artifactory/cloudera-repos/</url>
      </repository>
    </repositories>
    <build>
  	<plugins>
  		<plugin>
  			<groupId>org.apache.maven.plugins</groupId>
  			<artifactId>maven-shade-plugin</artifactId>
  		</plugin>
  	</plugins>
    </build>


![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image029.png?raw=true)

    package ca.lambton.bigdata.hadoop.wordcount2;

    import java.io.IOException;
    import org.apache.hadoop.conf.Configuration;
    import org.apache.hadoop.fs.Path;
    import org.apache.hadoop.io.IntWritable;
    import org.apache.hadoop.io.LongWritable;
    import org.apache.hadoop.io.Text;
    import org.apache.hadoop.mapreduce.Job;
    import org.apache.hadoop.mapreduce.Mapper;
    import org.apache.hadoop.mapreduce.Reducer;
    import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
    import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;

    public class WordCount {
	
	public static void main(String [] args) throws Exception {

		Configuration c=new Configuration();
		Job j=new Job(c,"wordcount");
		j.setJarByClass(WordCount.class);
		j.setMapperClass(MapForWordCount.class);
		j.setReducerClass(ReduceForWordCount.class);
		j.setOutputKeyClass(Text.class);
		j.setOutputValueClass(IntWritable.class);
		FileInputFormat.addInputPath(j, new Path(args[0]));
		FileOutputFormat.setOutputPath(j, new Path(args[1]));
		System.exit(j.waitForCompletion(true)?0:1);
	}

	public static class MapForWordCount extends Mapper<LongWritable, Text, Text, IntWritable>{

		public void map(LongWritable key, Text value, Context con) throws IOException, InterruptedException {

			String line = value.toString();
			String[] words=line.split(" ");
			for(String word: words ) {
				Text outputKey = new Text(word.toUpperCase().trim());
				IntWritable outputValue = new IntWritable(1);
				con.write(outputKey, outputValue);
			}

		}

	}

	public static class ReduceForWordCount extends Reducer<Text, IntWritable, Text, IntWritable> {

		public void reduce(Text word, Iterable<IntWritable> values, Context con) throws IOException, InterruptedException {

			int sum = 0;
			for(IntWritable value : values) {
				sum += value.get();
			}
			con.write(word, new IntWritable(sum));
		}

	}

    }

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image030.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image031.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image032.png?raw=true)

## Step 1-2) MapReduce program execution

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image033.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image034.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image035.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image036.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image037.png?raw=true)

> Low CPU, memory and disk used on master during the job execution:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image038.png?raw=true)

> High CPU, memory and disk used on the slaves during the job execution:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image039.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image040.png?raw=true)

> Job concluded after 5 hours and 30 minutes:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image041.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image042.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image043.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image044.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image045.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image046.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image047.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image048.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image049.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image050.png?raw=true)

## Step 2-1) Spark program implementation

> Eclipse configuration:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image051.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image052.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image053.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image054.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image055.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image056.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image057.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image058.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image059.png?raw=true)

> https://github.com/spark-in-action/scala-archetype-sparkinaction/raw/master/archetype-catalog.xml

> Create the project:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image060.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image061.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image062.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image063.png?raw=true)

    package ca.lambton.spark.training.wordcountspark


    import org.apache.spark.SparkContext
    import org.apache.spark.SparkContext._
    import org.apache.spark.SparkConf

    object App {
      def main(args: Array[String]) {
        // create Spark context with Spark configuration
        val sc = new SparkContext(new SparkConf().setAppName("Spark Count"))

        // get threshold
        val threshold = 1000

        // read in text file and split each document into words
        val tokenized = sc.textFile(args(0)).flatMap(_.split(" "))

        // count the occurrence of each word
        val wordCounts = tokenized.map((_, 1)).reduceByKey(_ + _)

        // filter out words with fewer than threshold occurrences
        val filtered = wordCounts.filter(_._2 >= threshold)

        filtered.saveAsTextFile(args(1))
      }
    }

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image064.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image065.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image066.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image067.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image068.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image069.png?raw=true)

# Step 2-1) Spark program execution

> Running Spark on YARN cluster:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image070.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image071.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image072.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image073.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image074.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image075.png?raw=true)

> Job concluded after 18 minutes:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image076.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image077.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image078.png?raw=true)

> Running Spark Standalone cluster mode:

> Copy the jar to all nodes:

    scp /home/hadoop/wordcountspark.jar  10.0.0.5:~/
    scp /home/hadoop/wordcountspark.jar  10.0.0.6:~/
    scp /home/hadoop/wordcountspark.jar  10.0.0.7:~/


![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image079.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image080.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image081.png?raw=true)

> Job concluded after 22 minutes:

![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image082.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image083.png?raw=true)
![](https://github.com/rembertmagri/bigdata-frameworks/blob/master/images/image084.png?raw=true)

## Step 3) Compare results

* MapReduce execution time: 5 hours 30 minutes
* Spark on YARN execution time: 18 minutes
* Spark Standalone cluster execution time: 22 minutes

This confirms what Apache Spark claims: that it is at least 10x faster than Hadoop's MapReduce.
