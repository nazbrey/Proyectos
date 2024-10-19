package main

import (
	"log"
	"net"

	pb "your_project_path/api/grpc" // Importar el paquete generado de gRPC
	"your_project_path/internal/config"
	"your_project_path/internal/infrastructure/grpc"

	"google.golang.org/grpc"
)

func main() {
	// Cargar la configuración (Kafka, Redis, DB, gRPC)
	cfg := config.LoadConfig()

	// Iniciar el servidor gRPC
	lis, err := net.Listen("tcp", cfg.GRPCPort)
	if err != nil {
		log.Fatalf("Error al iniciar el servidor gRPC: %v", err)
	}

	grpcServer := grpc.NewServer()
	pb.RegisterActionServiceServer(grpcServer, grpc.NewActionGRPCServer()) // Registrar el servidor gRPC

	log.Printf("Servidor gRPC escuchando en %s", cfg.GRPCPort)

	if err := grpcServer.Serve(lis); err != nil {
		log.Fatalf("Error al ejecutar el servidor gRPC: %v", err)
	}
}
