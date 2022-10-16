using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.RPC;
using SolidityPart.Contracts.Voting.ContractDefinition;
using UnityEngine;
using UnityEngine.UI;

public class YesBlockController : MonoBehaviour
{
    private string url = "https://eth-goerli.g.alchemy.com/v2/UXgu_EbyllMg_u-9zYBiUB8q1k26QiQa";
    private string contractAddress = "0xa5eEdFeE89B5F181343AD612c48eFAf8FcF01a42";

    private GameObject pKWindow;
    private Text pK;

    private GameObject mPWindow;
    private Text mP;
    private byte[] mPArrey;
    private List<byte[]> mPList = new List<byte[]>();

    private GameObject ballotIdWindow;
    private Text ballotId;

    private void Start()
    {
        pKWindow = GameObject.Find("pKWindow");
        pK = (pKWindow.GetComponentInChildren<InputField>()).GetComponentInChildren<Text>();

        mPWindow = GameObject.Find("mPWindow");
        mP = (mPWindow.GetComponentInChildren<InputField>()).GetComponentInChildren<Text>();

        mPArrey = System.Text.Encoding.Default.GetBytes(mP.text);
        foreach (byte b in mPArrey)
        {
            var bA = new byte[] { b };
            mPList.Add(bA);
        }

        ballotIdWindow = GameObject.Find("ballotIdWindow");
        ballotId = (ballotIdWindow.GetComponentInChildren<InputField>()).GetComponentInChildren<Text>();

    }

    private void OnMouseDown()
    {
        StartCoroutine("AddYesVoice");
    }

    public IEnumerator AddYesVoice()
    {
        var transactionTransferRequest = new TransactionSignedUnityRequest(url, pK.text);
        var transactionMessage = new VoteForFunction
        {
            BallotId = BigInteger.Parse(ballotId.text),
            MerkleProof = mPList,
        };

        yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
    }
}
