# Seriloger
Serilog with ELK Stack


## Running the project:
1. Install Java JDK http://www.oracle.com/technetwork/java/javase/downloads/index.html -> _jdk-10_windows-x64_bin.exe_ 
2. Install Elastic Search https://www.elastic.co/guide/en/elasticsearch/reference/current/_installation.html -> _https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-6.2.3.msi_
3. Check, if service is running: http://localhost:9200/
4. Install Kibana https://www.elastic.co/guide/en/kibana/current/windows.html -> _https://artifacts.elastic.co/downloads/kibana/kibana-6.2.3-windows-x86_64.zip_
5. Unzip and run Kibana _.\bin\kibana.bat_ -> http://localhost:5601
6. Install Kibana as a Service:  
_sc create "ElasticSearch Kibana 6.2.3" binPath= "C:\kibana-6.2.3-windows-x86_64\bin\kibana.bat" depend= "Elasticsearch"_ 
7. To delete a Service:  
_sc delete "ElasticSearch Kibana 6.2.3"_)
