# Prerequisites

1. Obtain an OpenAI API Key 
2. Telerik UI for Blazor
3. Apply User Secrets to TelerikBlazorApp1

## OpenAI Keys

Note: The demo currently shows how to use Azure OpenAI. Other AI models can also be used with modification.

- Azure OpenAI: https://azure.microsoft.com/en-us/products/ai-services/openai-service/
- Azure AI Vision: https://azure.microsoft.com/en-us/products/ai-services/ai-vision/
- Azure Speech: https://azure.microsoft.com/en-us/products/ai-services/ai-speech/

## Telerik UI for Blazor

A free trial can be obtained from https://www.telerik.com/

You will need to modify the project accordingly when using a free trial.
See: https://docs.telerik.com/blazor-ui/getting-started/web-app#41-add-the-telerik-ui-for-blazor-client-assets
Note the items marked `For Trial licenses, use` in the documentation. These items will need to be updated in the project.

## User Secrets Schema


{
  // Use User Secrets or Environment Variables to set the values below
  // Do not share your API keys
  "ApiKey": "Your Azure OpenAI key",
  "DeploymentName": "Your Deployment Name",
  "Endpoint": "Your Azure OpenAI Endpoint",
  "SpeechApiKey": "Your Azure Cognitive Services Key",
  "ServiceRegion": "Your Service Region",
  "VisionApiKey": "Your Vision Key",
  "VisionEndpoint": "Your Vision Endpoint"
}