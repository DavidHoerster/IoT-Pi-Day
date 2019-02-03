# Setting up the Raspberry Pi

## Install Raspbian & Dot Net Core Runtime 2.2

## Headless installation of Raspbian
- Install Raspbian on your Pi.
    - Create a working folder on C: drive, name it **Raspbian**
    - Click [Raspbian Stretch with desktop](https://www.raspberrypi.org/downloads/
), then click **Download Zip** and save it to **C:\Raspbian**.
    - From Windows Explorer, navigate to **C:\Raspbian**.
    - Open a Command Prompt as Adminstrator and navigate to **C:\Raspbian**.
    - After download completes, **Right-Click** on **2018-xxx.zip** file to unzip the contents and create the **2018-xxx.img** file.
    - Insert & format the SD Card using a SD formatting tool.
        - Use [SD Memory Card Formatter](https://www.sdcard.org/downloads/formatter_4/eula_windows/index.html) tool.
    - Burn the file **2018-xxx.img** file to the SD card.
        - Use [BalenaEtcher](https://www.balena.io/etcher/?ref=etcher_footer).
    > **EXTREMELY IMPORTANT** - Once flashing is complete, create a new empty file named **ssh** (with no extension) in the root folder of the SD card drive.
    - Eject the SD card and insert it into the slot on the Raspberry Pi.
    - Plug the Raspberry Pi into your laptop via USB
        > TBD - Plug the Raspberry Pi into your laptop via RJ45?
    - Plug power into the Raspberry Pi.
    - Wait 4-5 min for it to fully boot up.
        - Time to grab another cup of joe! :coffee:
    - Locate the IP address which has been assigned by your DHCP server to the Raspberry Pi and make note of it.
    - Open a Command Prompt as an Administrator.
        - type: **ping -c 1 raspberrypi.local** to get it.

## Telnet into the Raspberry Pi using SSH

- **Option 1** - Using Windows 10
    - Click [How to Enable and Use Windows 10’s New Built-in SSH Commands](https://www.howtogeek.com/336775/how-to-enable-and-use-windows-10s-built-in-ssh-commands/)

- **Option 2** - Not using Windows 10
    - Download the PuTTY SSH and Telnet client and launch it.
        - Click [Download PuTTY](https://www.putty.org/) and click **Download it here** to download the latest version. Use the **MSI Windows Installer - 64-bit**.
        - Click **Run** to accept the default prompts.
        - Run **PuTTY** and enter the IP address of the Raspberry Pi and click Open. Accept the message about keys.
        - Enter **pi** as the logon name, and **raspberry** as the password.
        - Change the default password for the pi user .
            - Type **passwd** to change it to **iotpiday** for the current user.

- **Option 3** - Use your favorate SSH tool.

## Update your system's package list
- Entering the following command: **sudo apt-get -y update**

## Install .Net Core Runtime
The following commands need to be run on the Raspberry Pi whilst connected over an SSH session.
```
// Note: This will use the apt-get package manager to install three prerequiste packages.
sudo apt-get -y install libunwind8 gettext**

wget https://dotnetcli.blob.core.windows.net/dotnet/Sdk/2.2.103/dotnet-sdk-2.2.103-linux-arm.tar.gz
wget https://dotnetcli.blob.core.windows.net/dotnet/aspnetcore/Runtime/2.2.1/aspnetcore-runtime-2.2.1-linux-arm.tar.gz

sudo mkdir /opt/dotnet

sudo tar -xvf dotnet-sdk-2.2.103-linux-arm.tar.gz -C /opt/dotnet/

// Note: This creates a destination folder and extract the downloaded package into it.
sudo tar -xvf aspnetcore-runtime-2.2.1-linux-arm.tar.gz -C /opt/dotnet/

// Note: This sets up a symbolic link.
sudo ln -s /opt/dotnet/dotnet /usr/local/bin

// Note: The Raspberry Pi itself is supported only as deployment target to run .Net Core apps.
dotnet –info to confirm installation.
```

## Create application folders
- **sudo mkdir HubwayApp**
- **sudo mkdir SenseHAT**

> Note: Many of these instructions were based off of the following, [Set up Raspian and .NET Core 2.0 on a Raspberry Pi](https://blogs.msdn.microsoft.com/david/2017/07/20/setting_up_raspian_and_dotnet_core_2_0_on_a_raspberry_pi/)
