# :camera: Amazon Rekognition Lambda S3 Image Analysis

## Overview
This project demonstrates the use of AWS services to analyze an image stored in an S3 bucket. By leveraging AWS Lambda, Amazon Rekognition, and S3, the project detects text, objects, and faces in the uploaded image.



## :bookmark_tabs: Table of Contents
- [Overview](#overview)
- [Features](#rocket-features)
- [Technologies Used](#computer-technologies-used)
- [Project Architecture](#triangular_ruler-project-architecture)
- [Examples](#bulb-examples)
- [Prerequisites](#warning-prerequisites)
- [Setup Instructions](#gear-setup-instructions)
- [Installation](#package-installation)
- [How to Test](#white_check_mark-how-to-test)
- [Resources](#books-resources)



## :rocket: Features
- Upload images to an S3 bucket for automatic processing.
- Detect and analyze text, objects, and faces in images using AWS Rekognition.
- Event-driven architecture powered by AWS Lambda.
- Scalable, serverless, and efficient processing.



## :computer: Technologies Used
- **Programming Language**: C# and AWS SDK for .NET
- **AWS Services**:
  -- :inbox_tray: Amazon S3
  -- :cloud: AWS Lambda
  -- :camera: Amazon Rekognition
  -- :watch: AWS CloudWatch



## :triangular_ruler: Project Architecture
### Visual Representation:


### Explanation:
- **Amazon S3**: Stores images uploaded by users.
- **AWS Lambda**: Processes the images by invoking AWS Rekognition APIs.
- **Amazon Rekognition**: Performs text, object, and face detection.
- **AWS CloudWatch**: Logs analysis results for monitoring and debugging.



## :bulb: Examples
### Input Example
Sample image uploaded to S3:  
![Example Image](Insert example image URL here)

### Output Example
Example Rekognition output:
```json
{
  "TextDetections": [
    { "DetectedText": "Sample", "Confidence": 99.0 }
  ],
  "Labels": [
    { "Name": "Car", "Confidence": 98.7 }
  ],
  "FaceDetails": [
    { "AgeRange": { "Low": 25, "High": 35 }, "Smile": { "Value": true } }
  ]
}
```



## :warning: Prerequisites
Before getting started, ensure the following:
- **AWS Account**: You must have an active AWS account.
- **IAM Role**: Create an IAM role with the following permissions:
-- AmazonS3ReadOnlyAccess
-- AmazonRekognitionReadOnlyAccess



## :gear: Setup Instructions
### AWS Account and IAM Role
1. Create an AWS account if you don’t already have one.
2. Log in to the AWS Management Console.
3. Create a new IAM role with the following policies:
- AmazonS3ReadOnlyAccess
- AmazonRekognitionReadOnlyAccess
4. Attach this role to your Lambda function later.

### S3 Bucket Creation
1. Navigate to the Amazon S3 service in the AWS Console.
2. Click Create Bucket and provide a unique name (e.g., image-analysis-bucket).
3. Set the region and configure public access settings based on your requirements.



## :package: Installation
### Deploy the Lambda Function
1.  Clone the GitHub repository:
``` bash
git clone <[repository_url](https://github.com/TanyaDThomas/Basic-Image-Recognition.git)>
cd <Basic-Image-Recognition>
```
2. Navigate to AWS Lambda in the AWS Console.
3. Create a new Lambda function.
4. Choose Author from scratch and select the runtime (e.g., Python, Node.js, C#).
5. Attach the previously created IAM role to the function.
6. Upload the function code as a ZIP file or use the AWS Console editor.

### Set Up S3 Event Trigger
1. In the Lambda function settings, configure an S3 trigger:
- Choose your S3 bucket.
- Select the event type as PUT (trigger when a file is uploaded).


  
## :white_check_mark: How to Test
1. After uploading the image to S3, check the Lambda function logs in AWS CloudWatch for output.
2. Look for log entries such as:
``` json
{
  "TextDetections": [
    { "DetectedText": "Sample", "Confidence": 99.0 }
  ],
  "Labels": [
    { "Name": "Car", "Confidence": 98.7 }
  ],
  "FaceDetails": [
    { "AgeRange": { "Low": 25, "High": 35 }, "Smile": { "Value": true } }
  ]
}
```
3. You can also test by uploading multiple images and verifying that each image triggers a corresponding Lambda execution.
### Another Way to Test: 
1. Got to the Lambda Function
2. Make sure you are in the Code tab and click test
3. Create a new event
4. Put in an event name
5. Save
6. Click test
7. You should see something close to the example as above.

   
## :books: Resources
- [AWS Rekognition Documentation](https://docs.aws.amazon.com/rekognition/latest/dg/Welcome.html)
- [AWS S3 Documentation](https://docs.aws.amazon.com/s3/index.html)
- [AWS Lambda Documentation](https://docs.aws.amazon.com/lambda/latest/dg/welcome.html)
- [AWS SDK for .NET Rekognition Code Examples](https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/csharp_rekognition_code_examples.html#actions)

  
