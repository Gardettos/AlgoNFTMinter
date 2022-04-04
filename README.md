# AlgoNFTMinter
I created this application to give Algorand NFT creators a desktop tool with a UI to easily manage, mint, and update their NFTs. This initial buildout is specific for minting with ARC69 - trait data must be in CSV format. 

Services provided as of 3/11: Batch minting (with ARC69), opt-ins, and transfers. Batch Pinata uploads
WIP: batch updating ARC69
 


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
	*Get one [here](https://www.pinata.cloud/)
* Private key mnemonic for creator account
	* If you plan to Opt-In/Transfer to a second wallet then you will need that wallets mnemonic as well
* Trait data formatted in CSV file
	* Initial buildout creates a basic ARC69 JSON string with this data


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
