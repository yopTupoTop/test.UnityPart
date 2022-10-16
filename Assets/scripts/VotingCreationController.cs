using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.RPC;
using SolidityPart.Contracts.Voting.ContractDefinition;
using UnityEngine;
using UnityEngine.UI;

public class VotingCreationController : MonoBehaviour
{
    private string url = "https://eth-goerli.g.alchemy.com/v2/UXgu_EbyllMg_u-9zYBiUB8q1k26QiQa";
    private string contractAddress = "0xa5eEdFeE89B5F181343AD612c48eFAf8FcF01a42";

    private Button createButton;
    private GameObject pKInput;
    private GameObject mPInput;
    private GameObject dataInput;

    private byte[] mPArrey;
    private List<byte[]> mPList = new List<byte[]>();

    private void Start()
    {
        createButton = GetComponentInChildren<Button>();
        pKInput = transform.Find("privateKey").gameObject;
        mPInput = transform.Find("merkleProof").gameObject;
        dataInput = transform.Find("data").gameObject;

        mPArrey = System.Text.Encoding.Default.GetBytes(mPInput.GetComponent<Text>().text);
        foreach (byte b in mPArrey)
        {
            var bA = new byte[] { b };
            mPList.Add(bA);
        }
    }

    private void Awake()
    {
        createButton.onClick.AddListener(AddVoting);   
    }

    private void AddVoting()
    {
        StartCoroutine("CreateVoting");
    }

    public IEnumerator CreateVoting()
    {
        var transactionTransferRequest = new TransactionSignedUnityRequest(url, pKInput.GetComponent<Text>().text);
        var transactionMessage = new CreateVotingFunction
        {
            Data = dataInput.GetComponent<Text>().text,
            MerkleProof = mPList,
        };

        yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
    }
}
