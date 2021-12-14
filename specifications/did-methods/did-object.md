# Trusted Digital Web "DID Object" Decentralized Identifier Method Specification
This specification defines the end-to-end lifecycle of DID Identifiers and DID Documents for "DID Objects", a key feature of the
Fully Decentralized Objects (FDOs) Framework, implemented by the Trusted Digitial Web[1]. 

This specification defines the following:
- "DID Object" Identifier Syntax and Construction
- "DID Object" DID Document CRUD Operations

NOTE: The term "DID Object" Identifier is synonomous with the term "DID Object" Decentralized Identifier.

This specification conforms to 
the requirements specified in the DID Decentralized Identifier specification[2] currently published by the W3C Credentials Community Group (CCG). 

The fabric that knits the world together is the Internet global communications network and the World Wide Web (WWW) 
software application that runs on top of the Internet.
The WWW enables individuals, governments, corporations, and other organizations to share, 
consume and interact with a universal sea of data and information representing every aspect of our lives and livelihoods.

The Trusted Digital Web (TDW) is a universal, trusted, frictionless, fully-integrated, standards-based, 
general-purpose, decentralized, end-to-end software and governance platform for global commerce, communication, and collaboration. 
The Trusted Digital Web is envisioned to be the next generation, decentralized, trusted replacement for the World Wide Web.

Every software component in the Trusted Digital Web technology architecture (including every smart contract) is implemented using a single
programming language and a single common set of tools and technologies:
the C# programming language, Microsoft Visual Studio, and
the cross-platform implementations of the .NET Core Framework and the Microsoft Common Languiage Runtime (CLR) runtime environment.

Verifiable Data Registry (VDR) support is provided by the Stratis Platform - a general-purpose, smart contact-enabled blockchain platform implemented 
using the same progamming language, tools and technologies used to implement the Trusted Digital Web.

## 1. Trusted Digital Web "DID Object" Identifier Method Name
The namestring that shall identify the "DID Object" Identifier Method is: `object`.

A DID Identifier that uses this method **MUST** begin with the following prefix: `did:object`. 
Per this DID Decentralized Identifier specification[2], the value of this string **MUST** be in lowercase.

## 2. Trusted Digital Web "DID Object" Identifier Format
"DID Object" Identifiers on the Trusted Digital Web **MUST** use the following format:
```
did-object-did = "did:object:" id-string 
id-string      = 1* idchar
idchar         = 1-9 / A-H / J-N / P-Z / a-k / m-z 
```
`id-string` is an encoded public key value computed using KERI key management techniques.
The KERI seed value can be any globally unique value including, for example, a composite database record key, object key, 
GUID value, or the value of a DID Identifier string. 
Trusted Digital Web "DID Object" Identifier `id-string` values are encoded using the Base58 encoding method.

`idchar` consists of all the characters in the Base58 char set which is first defined by Bitcoin. 

### Example 1. Trusted Digital Web "DID Object" Identifier
```
did:object:AGsL32ZMvAwxYRN9Sv4mrgu3DgBSvTm5vt
```
## 3. CRUD Operations
"DID Object" Identifiers and associated DID Documents on the Trusted Digital Web are managed by the Trusted Digital Web Runtime Library. 
The Library provides CRUD interfaces for controlling the lifecycle of a "DID Object" Identifier and its associated DID Document.
 
### 3.1 Create (Register)

To create a "DID Object" Identifier, a program invokes the `RegIdWithPublicKey` function of the Trusted Digital Web Runtime Library. 
The interface to register a "DID Object" Identifier and its associated public key is defined as follows:
```csharp
public bool RegIdWIthPublicKey(string didobjectid, byte[] publicKey); 
```
The calling program must include two parameters: the string value of the new "DID Object" Identifier to be registered and a cryptographic 
public key to act as the first management key. 
This function will return `True` if the "DID Object" Identifier had not been registered previously.

### 3.2 Read (Resolve)

Trusted Digital Web "DID Object" Identifier's associated DID Document can be looked up by invoking the `GetDIDDocument` function of the Trusted Digital Web Runtime Library. 
To make sure the result returned by invoking the `GetDIDDocument` function is trustworthy, the client could ask a sufficient number of nodes 
and compare each node's return value.

The interface for resolving a "DID Object" Identifier and return its associated DID Document is defined as follows:
```csharp
public DIDDocument GetDIDDocument(string didobjectid);
```
A DIDDocument is a JSON-object which contains the `publicKey`, `authentication` elements of the associated DID Document.
Every public key in the array of `publicKey` can be used to authenticate the "DID Object" Controller.

Note: The list of supported public key signature schemes is listed in [Appendix A](#appendix-a-public-key-algorithm).

### Example 2. "DID Object" DID Document
```json
{
    "id": "did:object:AGsL32ZMvAwxYRN9Sv4mrgu3DgBSvTm5vt",
    "publicKey": [{
        "id": "did:object:AGsL32ZMvAwxYRN9Sv4mrgu3DgBSvTm5vt#keys-1",
        "type": ["ECDSA", "secp256r1"],
        "publicKeyHex": "02ba8ba8e8ef1f313ecc095ba0bf0d1a921a138346d6817812714f4a9e4cca8ccf"
    }, {
        "id": "did:object:AGsL32ZMvAwxYRN9Sv4mrgu3DgBSvTm5vt#keys-2",
        "type": ["ECDSA", "secp256r1"],
        "publicKeyHex": "02b9bd513110b2a7822326280f3fdff9fa667649d3302428a0ab6fb796c6f3201b"
    }],
    "authentication": [{
        "type": "Secp256r1SignatureAuthentication2018",
        "publicKey": "did:object:AGsL32ZMvAwxYRN9Sv4mrgu3DgBSvTm5vt#keys-1"
    }, {
        "type": "Secp256r1SignatureAuthentication2018",
        "publicKey": "did:object:AGsL32ZMvAwxYRN9Sv4mrgu3DgBSvTm5vt#keys-2"
    }],
}
```

### 3.3 Update (Replace)

To update the DID Document associated with a "DID Object" Identifier, two functions need to be invoked, 
```csharp
public bool AddKey(string didobjectid, byte[] newPublicKey, byte[] sender);
```
```csharp
public bool RemoveKey(string didobjectid, byte[] oldPublicKey, byte[] sender);
```
Note that `sender` param must be a currently-in-use public key of this "DID Object" Identifier.
If a public key is removed, then it **cannot** be added again.

### 3.4 Delete (Revoke)

To delete or deactivate a "DID Object", it suffices to remove all public keys from its associated 
DID Document. In this case, there is no public key that can be used to authenticate the "DID Object" Controller.

More importantly, deletion of a Trusted Digital Web "DID Object" DID Document means that the associated "DID Object" Identifier cannot be reactivated again. 

## 4. Security Considerations
TODO

## 5. Privacy Consideration
TODO

## 6. Reference Implementations
The code for the "DID Object" Identifier Method reference implementation can be found in the following GitHub project: https://github.com/mwherman2000/TrustedDigitalWeb. 
This project is the definitive reference implementation of Trusted Digital Web "DID Object" Identifier Method.

## Appendix A. Public Key Algorithm 
There are three public key algorithms supported in this document. 
1. ECDSA
2. SM2
3. EdDSA

### ECDSA 
The curves that can be used are: 

- secp224r1 -- same as nistp224
- secp256r1 -- same as nistp256 
- secp384r1 -- same as nistp384 
- secp521r1 -- same as nistp521

More curves may be supported in future versions of this Method. 

### SM2 

There is only one curve that can be used, namely, `sm2p256v1` as defined in [SM2 Digital Signature Algorithm](https://tools.ietf.org/html/draft-shen-sm2-ecdsa-02#appendix-D). 

### EdDSA
There is only one curve that can be used, namely, `ed25519`. 

## References
[1]. Trusted Digital Web: Whitepaper, https://hyperonomy.com/2019/11/06/trusted-digital-web-whitepaper/.

[2]. W3C Decentralized Identifiers (DIDs) v0.11, https://w3c-ccg.github.io/did-spec/.

[3]. IETF Internet draft, SM2 Digital Signature Algorithm, https://tools.ietf.org/html/draft-shen-sm2-ecdsa-02.

## Credits
The text of this specification was adapted from the `did:ont` specification, https://github.com/ontio/ontology-DID/blob/master/docs/en/DID-ONT-method.md.
