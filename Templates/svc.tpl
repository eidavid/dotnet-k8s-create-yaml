apiVersion: v1
kind: Service
metadata:
  name: @name@@namespace@
spec:@ports@
  selector:
    app: @app@
  sessionAffinity: None
  type: @type@