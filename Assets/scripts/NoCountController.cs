using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.JsonRpc.UnityClient;
using SolidityPart.Contracts.Voting.ContractDefinition;
using UnityEngine;
using UnityEngine.UI;

public class NoCountController : MonoBehaviour
{
    private string url = "https://eth-goerli.g.alchemy.com/v2/UXgu_EbyllMg_u-9zYBiUB8q1k26QiQa";
    private string contractAddress = "0xa5eEdFeE89B5F181343AD612c48eFAf8FcF01a42";

    [SerializeField] private TextMesh countText;
    private BigInteger id;
    private GameObject ballotIdWindow;
    private string ballotId;

    private void Start()
    {
        ballotIdWindow = GameObject.Find("ballotIdWindow");
        Debug.Log(ballotIdWindow);
        ballotId = ballotIdWindow.GetComponentInChildren<InputField>().GetComponentInChildren<Text>().text;
        Debug.Log(ballotId);
        id = BigInteger.Parse(ballotId);

        NoBlockController.NoVoiceAdded += UpdateNoCount;
        StartCoroutine("ChangeNoCount");
    }

    private void UpdateNoCount()
    {
        StartCoroutine("ChangeNoCount");
    }

    public IEnumerator ChangeNoCount()
    {

        var queryRequest = new QueryUnityRequest<IdToBallotFunction, IdToBallotOutputDTO>(url, contractAddress);
        yield return queryRequest.Query(new IdToBallotFunction() { ReturnValue1 = id }, contractAddress);

        countText.text = queryRequest.Result.NoCount.ToString();
    }
}
