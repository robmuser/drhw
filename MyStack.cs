using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;

class MyStack : Stack
{
    public MyStack()
    {
        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup("rg", new ResourceGroupArgs{
            ResourceGroupName = "rg-webapphelloworld",
            Location = "Australia East",

        });

        var appServicePlan = new AppServicePlan("asp", new AppServicePlanArgs
        {
            Name = "asp-webapphelloworld",
            Location = resourceGroup.Location,
            ResourceGroupName = resourceGroup.Name,
            Kind = "App",
            Sku = new SkuDescriptionArgs
            {
                Tier = "Free",
                Name = "F1",
            },
        });  
        var webApp = new WebApp("webapp", new WebAppArgs
        {
            Name = "app-webapphelloworld",
            Location = resourceGroup.Location,
            ResourceGroupName = resourceGroup.Name,
            ServerFarmId = appServicePlan.Id,

        }); 
    }
  
}
