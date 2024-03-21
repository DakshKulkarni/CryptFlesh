using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;

public class UnityScript : MonoBehaviour
{
     public TMPro.TextMeshProUGUI text;
     public const string ContractAddress = "0x0fA5931B013438C4446f0dac6D22737F1ABCf094";
     public async void ChangeTextToAddress()
     {
        var results = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
        text.text = results;
     }
     public async void GetNFTBalance()
     {
        text.text="Getting balance...";
        Contract contract =  ThirdwebManager.Instance.SDK.GetContract(ContractAddress);
        var results = await contract.ERC721.Balance();
        text.text = results;
     }

     public async void ClaimNFT()
     {
        try
        {
            text.text="Claming NFT...";
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ContractAddress);
            var results = await contract.ERC721.Claim(1);
            text.text="NFT Claimed!";
        }
        catch(System.Exception)
        {
            Debug.Log("Error Claming NFT");
        }
     }
}
