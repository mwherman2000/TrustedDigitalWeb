using (var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "http://localhost:8080/CreateTDWCredential/"))
{
    List<string> context = new List<string> { "https://www.sovrona.com/ns/svrn/v1" };

    List<TCSClaim> claims = new List<TCSClaim>();
    claims.Add(new TCSClaim("authentication", null,
        new List<TCSKeyValuePair> {
            new TCSKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
            new TCSKeyValuePair( "id", "#pubkey1"),
            new TCSKeyValuePair( "type", "AUTHN-KEY")
            }));

    claims.Add(new TCSClaim("service", null,
        new List<TCSKeyValuePair> {
            new TCSKeyValuePair( "serviceEndPoint", "http://localhost:5304/"),
            new TCSKeyValuePair( "id", "#sep1"),
            new TCSKeyValuePair( "type", "SEP-TCS")
            }));

    claims.Add(new TCSClaim("testkey1", "testvalue1"));

    List<TCSKeyValuePair> attr1 = new List<TCSKeyValuePair> {
        new TCSKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
        new TCSKeyValuePair( "id", "#pubkey1"),
        new TCSKeyValuePair( "type", "AUTHN-KEY")
    };
    List<TCSKeyValuePair> attr2 = new List<TCSKeyValuePair> {
        new TCSKeyValuePair( "publicKey", "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ"),
        new TCSKeyValuePair( "id", "#pubkey2"),
        new TCSKeyValuePair( "type", "AUTHN-KEY")
    };
    List<List<TCSKeyValuePair>> attrslist = new List<List<TCSKeyValuePair>> { attr1, attr2 };
    TCSClaim testclaim2 = new TCSClaim("testkey2", null, null, attrslist);
    claims.Add(testclaim2);

    var comments = new List<string> { "Bob's UDID Document", "It works!", 
                                      "Created by TDW.TCSServer at " + DateTime.Now.ToString("u") };

    requestMessage.Headers.TryAddWithoutValidation("Accept", "application/json");
    TDWCreateTDWCredentialRequest request = new TDWCreateTDWCredentialRequest(TCSCredentialType.UDIDDocument, 
                                                                              context, claims,
                                                                              TCSTrustLevel.SignedHashSignature, 
                                                                              TCSEncryptionFlag.NotEncrypted, 
                                                                              comments, keypairsalt);
    string jsonRequest = JsonConvert.SerializeObject(request);
    requestMessage.Content = new StringContent(jsonRequest);
    var task = httpClient.SendAsync(requestMessage);
    task.Wait();
    var result = task.Result;
}

