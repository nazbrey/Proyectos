package config

import (
	"log"
	"os"
)

type Config struct {
	GRPCPort string
	KafkaURL string
	RedisURL string
}

func LoadConfig() *Config {
	return &Config{
		GRPCPort: getEnv("GRPC_PORT", ":50051"),
		KafkaURL: getEnv("KAFKA_URL", "localhost:9092"),
		RedisURL: getEnv("REDIS_URL", "localhost:6379"),
	}
}

func getEnv(key, defaultValue string) string {
	value, exists := os.LookupEnv(key)
	if !exists {
		log.Printf("Usando valor por defecto para %s: %s", key, defaultValue)
		return defaultValue
	}
	return value
}
