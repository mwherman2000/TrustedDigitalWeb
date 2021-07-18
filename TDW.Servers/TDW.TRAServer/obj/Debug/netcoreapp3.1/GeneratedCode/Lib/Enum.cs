#pragma warning disable 162,168,649,660,661,1522
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinity;
using Trinity.TSL;
namespace TDW.TRAServer
{
    
    /// <summary>
    /// Represents the enum type TRATrustLevel defined in the TSL.
    /// </summary>
    public enum TRATrustLevel : byte
    {
        Undefined = 0,UnResolvable = 1,Unsigned = 2,HashedThumbprint = 3,SignedHashSignature = 4,Notarized = 5,CorruptSignatures = 6
    }
    
    /// <summary>
    /// Represents the enum type TRAEncryptionFlag defined in the TSL.
    /// </summary>
    public enum TRAEncryptionFlag : byte
    {
        NotEncrypted = 0,Encrypted = 1
    }
    
    /// <summary>
    /// Represents the enum type TRACredentialType defined in the TSL.
    /// </summary>
    public enum TRACredentialType : byte
    {
        GenericCredential = 0,UDIDDocument = 1,VerifiableCredential = 2,NotarizedCredential = 3,VerifiableCapabilityAuthorization = 4,MasterVerifiableCapabilityAuthorization = 5,ServerCertificate = 6,RevocationCertificate = 7
    }
    
    /// <summary>
    /// Represents the enum type TRAServiceType defined in the TSL.
    /// </summary>
    public enum TRAServiceType : byte
    {
        Unknown = 0,ResourceService = 1,StorageService = 2,KeyManagementService = 3,MasterKeyManagementService = 4,AuthenticationService = 5,VerifiableDataRegistryService = 6
    }
    
    /// <summary>
    /// Represents the enum type ISO639_1_LanguageCodes defined in the TSL.
    /// </summary>
    public enum ISO639_1_LanguageCodes : byte
    {
        en = 0,ab = 1,aa = 2,af = 3,ak = 4,sq = 5,am = 6,ar = 7,an = 8,hy = 9,as_ = 10,av = 11,ae = 12,ay = 13,az = 14,bm = 15,ba = 16,eu = 17,be = 18,bn = 19,bh = 20,bi = 21,bs = 22,br = 23,bg = 24,my = 25,ca = 26,ch = 27,ce = 28,ny = 29,zh = 30,zh_Hans = 31,zh_Hant = 32,cv = 33,kw = 34,co = 35,cr = 36,hr = 37,cs = 38,da = 39,dv = 40,nl = 41,dz = 42,eo = 43,et = 44,ee = 45,fo = 46,fj = 47,fi = 48,fr = 49,ff = 50,gl = 51,gd = 52,gv = 53,ka = 54,de = 55,el = 56,kl = 57,gn = 58,gu = 59,ht = 60,ha = 61,he = 62,hz = 63,hi = 64,ho = 65,hu = 66,is_ = 67,io = 68,ig = 69,id = 70,in_ = 71,ia = 72,ie = 73,iu = 74,ik = 75,ga = 76,it = 77,ja = 78,jv = 79,kn = 80,kr = 81,ks = 82,kk = 83,km = 84,ki = 85,rw = 86,rn = 87,ky = 88,kv = 89,kg = 90,ko = 91,ku = 92,kj = 93,lo = 94,la = 95,lv = 96,li = 97,ln = 98,lt = 99,lu = 100,lg = 101,lb = 102,mk = 103,mg = 104,ms = 105,ml = 106,mt = 107,mi = 108,mr = 109,mh = 110,mo = 111,mn = 112,na = 113,nv = 114,ng = 115,nd = 116,ne = 117,no = 118,nb = 119,nn = 120,ii = 121,oc = 122,oj = 123,cu = 124,or = 125,om = 126,os = 127,pi = 128,ps = 129,fa = 130,pl = 131,pt = 132,pa = 133,qu = 134,rm = 135,ro = 136,ru = 137,se = 138,sm = 139,sg = 140,sa = 141,sr = 142,sh = 143,st = 144,tn = 145,sn = 146,sd = 147,si = 148,ss = 149,sk = 150,sl = 151,so = 152,nr = 153,es = 154,su = 155,sw = 156,sv = 157,tl = 158,ty = 159,tg = 160,ta = 161,tt = 162,te = 163,th = 164,bo = 165,ti = 166,to = 167,ts = 168,tr = 169,tk = 170,tw = 171,ug = 172,uk = 173,ur = 174,uz = 175,ve = 176,vi = 177,vo = 178,wa = 179,cy = 180,wo = 181,fy = 182,xh = 183,ji = 184,yi = 185,yo = 186,za = 187,zu = 188
    }
    
}

#pragma warning restore 162,168,649,660,661,1522
