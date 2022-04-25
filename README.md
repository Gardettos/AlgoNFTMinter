# AlgoNFTMinter
***Note: This readme is a WIP***

I created this application to give Algorand NFT creators a desktop tool with a UI to easily manage, mint, and update their NFTs. This initial buildout is specific for minting with ARC69 - trait data must be in CSV format. 

Services provided as of 3/11: Batch minting (with ARC69), opt-ins, and transfers. Batch Pinata uploads  
WIP: batch updating ARC69
 
![image](https://user-images.githubusercontent.com/77548895/165172221-9299b8e4-7cd8-4930-b81c-a5745ac21800.png)

 
System Requirements:
* Application only runs on MSFT Windows OS
	* This is a Windows Forms Application built in C# .NET Core 3.1
* Visual Studio - I'm using the Community 2019 edition. 
	* I recommend downloading the latest Visual Studio community edition [here](https://visualstudio.microsoft.com/) 
	* I recommend the beefy version of Visual Studio because it comes with everything needed to run a Windows Form .NET Application. 
		* I've never tried to run in VS Code, but if that can be done then be my guest to try running it there. 
	* You can run the application directly from Visual Studio in debug mode or you can compile an exe to run if you so choose  
* Algod API Key
	* If you need a key, you can sign up and get one [here](https://www.purestake.com/technology/algorand-api/)
	* It will be the same API key for both Main Net, Test Net, and the Indexers
* IPFS/Pinata API Key and Secret
	* Get one [here](https://www.pinata.cloud/)
* Private key mnemonic for creator account
	* If you plan to Opt-In/Transfer to a second wallet then you will need that wallets mnemonic as well
	
Required packages:
```
Microsoft.Extensions.Configuration
Microsoft.Extensions.Configuration.FileExtensions
Microsoft.Extensions.Configuration.Json
Algorand
Pinata.Client
sqlite-net-pcl
CsvHelper
```

Setting Up:
* Once Visual Studio is installed, you will then need to install all the required packages above via NuGet. 
	* Open the .sln file found in this repo with VS
	* In the dropdown select: Project -> Manage NuGet Packages
	* Select 'Browse' and then search for and install all the packages listed above
![image](https://user-images.githubusercontent.com/77548895/163883714-302805a1-9e3a-4f02-8341-909fc3dddb6f.png)
![image](https://user-images.githubusercontent.com/77548895/163883845-8037c47c-7828-4951-81c5-e1b5e194c0ba.png)
	
	
* Next you will need to update the configuration file with our required values
	* In the solution explorer, open up 'AppSettings.json' and populate
	* The file should look something like the below example 
	
![image](https://user-images.githubusercontent.com/77548895/163884430-c125b209-b9d1-4f73-ba86-78389b5f96b2.png)
![image](https://user-images.githubusercontent.com/77548895/163884819-5b4db6c2-6d3a-485a-9870-c22e8b44df46.png)

***Note: This application uses the open source sqlite-net-pcl library to store data. The value assigned to databaseLocation is the location of the folder we want the  database file to be saved to. You will never have to manually interact with the file, but the location to save it to is something you will neeed to decide on before running. It is a small file ( <1 MB)***

Running Application:  
***This is a WIP***
