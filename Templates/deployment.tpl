apiVersion: apps/v1
kind: Deployment
metadata:@labels@
  name: @name@@namespace@
spec:
  replicas: @replicas@
  selector:
    matchLabels:
      app: @name@
  strategy:
    rollingUpdate:
      maxSurge: 25%
      maxUnavailable: 25%
    type: RollingUpdate
  template:
    metadata:@annotations@@labelsTemplate@
    spec:@containers@@imagePullSecrets@