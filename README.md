# Azure Functions on K8s

## Introduction

This project provides:

1. a simple Azure Function with a queue listener
2. a set of instructions for deploying the function to a k8s cluster, optionally using AKS
3. a test program for adding messages to the queue

## Creating a function with a Docker file

This step is optional, but it explains how to create a Docker enable function.

You will need to have the Azure Function CLI installed to use the `func` tools. You can find the [Azure Functions Core Tools installation instructions here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash#install-the-azure-functions-core-tools).

Instructions for creating a [k8s enabled function can be found here](https://docs.microsoft.com/en-us/azure/azure-functions/functions-kubernetes-keda).

`func init --docker-only`