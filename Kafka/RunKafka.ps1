echo "Create Network Driver"
docker network create app-tier --driver bridge
echo "Create Zookeepr Server"
docker run -d --name zookeeper-server --network app-tier -p 22181:2181 -e ALLOW_ANONYMOUS_LOGIN=yes bitnami/zookeeper:latest
echo "Create Kafka Server"
docker run -d --name kafka-server --network app-tier -p 29092:29092 -e ALLOW_PLAINTEXT_LISTENER=yes -e KAFKA_CFG_ZOOKEEPER_CONNECT=zookeeper-server:2181 bitnami/kafka:latest