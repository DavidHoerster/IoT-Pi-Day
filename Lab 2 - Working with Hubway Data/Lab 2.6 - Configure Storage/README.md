# Lab 2.6 - Configure Storage
We need to document the scenario here

## Prerequisites
1. The Resource Configuation Lab is completed, see [Lab 1.0 - Resource Configuration](https://github.com/Azure/IoT-Pi-Day/tree/master/Lab%201%20-%20Getting%20started%20with%20the%20Sense%20HAT/Lab%201.0%20-%20Resource%20Configuration)
2. The Resource Configuation Lab is completed, see [Lab 2.0 - Resource Configuration](https://github.com/Azure/IoT-Pi-Day/tree/master/Lab%202%20-%20Working%20with%20Hubway%20Data/Lab%202.0%20-%20Resource%20Configuration)
3. Completion of Lab 2.1 through 2.5 must be done.

## Estimated time to complete
- TBD

## Creating the Blob container
🚨 In this section, we will be creating a container to store the the hubway data.

1. Navigate to the resource group.

    - From the Azure Portal from the left menu, click on **Resource Groups**.
    - Select the resource group created previously, i.e. **<*lastname*>-piday-rg**.
    - Click on the Storage Account created earlier, i.e. **<*lastname*>pidaydatastorage**.

        ![Image](/images/lab-0-imagex.png)

2. Create the Blob Container

    - Under **Blob service**, click **Blobs**.
    - On the right, click **+ Container** to add a container.
    - Enter a name for your blob container, type **boston-hubway-data**.
    - Select **Private(no anonymous access)**.
    - Click **OK** to create the container.

        ![Image](/images/lab-2.6-image4.png)

## Configure the Blob service for static website hosting

1. Enable the Static Web Site
    - Under **Settings**, click **Static website**.
    - Under **Static website**, click **Enabled** to enable you to host static content in your storage account.
    - Click **Save**.

    ![Image](/images/lab-2.6-image5.png)

    - Notice the **$web** folder that is created
    - Take note of the Primary endpoint, as you will need this URL later.

        ![Image](/images/lab-2.6-image6.png)

## View Containers
1.  Verify containers were created.
    - Click **Storage Explorer (preview)**.
    - Click **BLOB CONTAINERS** to expand the tree structure.
    - You should have two containers:
        - **$web**
        - **boston-hubway-data**

    ![Image](/images/lab-2.6-image7.png)

## Reference Sites

[Create an Azure Storage Account](https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal)

[Azure Blob Storage](https://azure.microsoft.com/en-us/services/storage/blobs/)
