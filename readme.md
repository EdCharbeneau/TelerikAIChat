# Prerequisites

1. Obtain an OpenAI API Key 
2. Telerik UI for Blazor
3. Apply User Secrets to TelerikBlazorApp1

## OpenAI Keys

Note: The demo currently shows how to use OpenAI. Azure OpenAI can also be used with modification. However, Azure OpenAI is in beta and requires special access.

https://platform.openai.com/account/billing/overview


## Telerik UI for Blazor

A free trial can be obtained from https://www.telerik.com/

You will need to modify the project accordingly when using a free trial.
See: https://docs.telerik.com/blazor-ui/getting-started/web-app#41-add-the-telerik-ui-for-blazor-client-assets
Note the items marked `For Trial licenses, use` in the documentation. These items will need to be updated in the project.

## User Secrets Schema

{
  "OpenAiKey": "your key here"
}