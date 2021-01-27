apiVersion: batch/v1beta1
kind: CronJob
metadata:@labels@
  name: @name@@namespace@
spec:
  schedule: "@schedule@"
  jobTemplate:
    spec:
      template:
        metadata:@annotations@@labelsTemplate@
        spec:@containers@@imagePullSecrets@
          restartPolicy: OnFailure
  suspend: @suspend@
