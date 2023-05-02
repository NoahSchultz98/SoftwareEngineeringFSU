; ModuleID = 'obj\Debug\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [206 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 66
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 84
	i32 101534019, ; 2: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 75
	i32 117431740, ; 3: System.Runtime.InteropServices => 0x6ffddbc => 96
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 75
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 53
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 76
	i32 209399409, ; 7: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 51
	i32 220171995, ; 8: System.Diagnostics.Debug => 0xd1f8edb => 6
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 63
	i32 230752869, ; 10: Microsoft.CSharp.dll => 0xdc10265 => 11
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 91
	i32 280482487, ; 12: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 61
	i32 318968648, ; 13: Xamarin.AndroidX.Activity.dll => 0x13031348 => 44
	i32 321597661, ; 14: System.Numerics => 0x132b30dd => 34
	i32 330147069, ; 15: Microsoft.SqlServer.Server => 0x13ada4fd => 21
	i32 342366114, ; 16: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 64
	i32 385762202, ; 17: System.Memory.dll => 0x16fe439a => 32
	i32 442521989, ; 18: Xamarin.Essentials => 0x1a605985 => 82
	i32 442565967, ; 19: System.Collections => 0x1a61054f => 4
	i32 450948140, ; 20: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 60
	i32 465846621, ; 21: mscorlib => 0x1bc4415d => 23
	i32 469710990, ; 22: System.dll => 0x1bff388e => 28
	i32 476646585, ; 23: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 61
	i32 485463106, ; 24: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 15
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 70
	i32 526420162, ; 26: System.Transactions.dll => 0x1f6088c2 => 90
	i32 545304856, ; 27: System.Runtime.Extensions => 0x2080b118 => 99
	i32 548916678, ; 28: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 10
	i32 577335427, ; 29: System.Security.Cryptography.Cng => 0x22697083 => 95
	i32 605376203, ; 30: System.IO.Compression.FileSystem => 0x24154ecb => 88
	i32 627609679, ; 31: Xamarin.AndroidX.CustomView => 0x2568904f => 57
	i32 634759996, ; 32: Codeholic.dll => 0x25d5ab3c => 0
	i32 662205335, ; 33: System.Text.Encodings.Web.dll => 0x27787397 => 40
	i32 663517072, ; 34: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 80
	i32 666292255, ; 35: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 48
	i32 672442732, ; 36: System.Collections.Concurrent => 0x2814a96c => 3
	i32 690569205, ; 37: System.Xml.Linq.dll => 0x29293ff5 => 43
	i32 722857257, ; 38: System.Runtime.Loader.dll => 0x2b15ed29 => 38
	i32 775507847, ; 39: System.IO.Compression => 0x2e394f87 => 87
	i32 809851609, ; 40: System.Drawing.Common.dll => 0x30455ad9 => 86
	i32 843511501, ; 41: Xamarin.AndroidX.Print => 0x3246f6cd => 72
	i32 928116545, ; 42: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 84
	i32 967690846, ; 43: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 64
	i32 975236339, ; 44: System.Diagnostics.Tracing => 0x3a20ecf3 => 97
	i32 992768348, ; 45: System.Collections.dll => 0x3b2c715c => 4
	i32 1012816738, ; 46: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 74
	i32 1035644815, ; 47: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 47
	i32 1052210849, ; 48: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 67
	i32 1062017875, ; 49: Microsoft.Identity.Client.Extensions.Msal => 0x3f4d1b53 => 14
	i32 1098259244, ; 50: System => 0x41761b2c => 28
	i32 1138436374, ; 51: Microsoft.Data.SqlClient.dll => 0x43db2916 => 12
	i32 1175144683, ; 52: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 78
	i32 1204270330, ; 53: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 48
	i32 1267360935, ; 54: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 79
	i32 1293217323, ; 55: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 59
	i32 1364015309, ; 56: System.IO => 0x514d38cd => 101
	i32 1365406463, ; 57: System.ServiceModel.Internals.dll => 0x516272ff => 102
	i32 1376866003, ; 58: Xamarin.AndroidX.SavedState => 0x52114ed3 => 74
	i32 1379779777, ; 59: System.Resources.ResourceManager => 0x523dc4c1 => 2
	i32 1406073936, ; 60: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 54
	i32 1411638395, ; 61: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 36
	i32 1457743152, ; 62: System.Runtime.Extensions.dll => 0x56e36530 => 99
	i32 1460893475, ; 63: System.IdentityModel.Tokens.Jwt => 0x57137723 => 30
	i32 1462112819, ; 64: System.IO.Compression.dll => 0x57261233 => 87
	i32 1469204771, ; 65: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 46
	i32 1498168481, ; 66: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 16
	i32 1582305585, ; 67: Azure.Identity => 0x5e501131 => 8
	i32 1582372066, ; 68: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 58
	i32 1592978981, ; 69: System.Runtime.Serialization.dll => 0x5ef2ee25 => 39
	i32 1622152042, ; 70: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 69
	i32 1628113371, ; 71: Microsoft.IdentityModel.Protocols.OpenIdConnect => 0x610b09db => 19
	i32 1636350590, ; 72: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 56
	i32 1639515021, ; 73: System.Net.Http.dll => 0x61b9038d => 33
	i32 1657153582, ; 74: System.Runtime => 0x62c6282e => 37
	i32 1658251792, ; 75: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 83
	i32 1701541528, ; 76: System.Diagnostics.Debug.dll => 0x656b7698 => 6
	i32 1726116996, ; 77: System.Reflection.dll => 0x66e27484 => 98
	i32 1729485958, ; 78: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 52
	i32 1766324549, ; 79: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 76
	i32 1776026572, ; 80: System.Core.dll => 0x69dc03cc => 25
	i32 1788241197, ; 81: Xamarin.AndroidX.Fragment => 0x6a96652d => 60
	i32 1794500907, ; 82: Microsoft.Identity.Client.dll => 0x6af5e92b => 13
	i32 1796167890, ; 83: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 10
	i32 1808609942, ; 84: Xamarin.AndroidX.Loader => 0x6bcd3296 => 69
	i32 1813201214, ; 85: Xamarin.Google.Android.Material => 0x6c13413e => 83
	i32 1867746548, ; 86: Xamarin.Essentials.dll => 0x6f538cf4 => 82
	i32 1871986876, ; 87: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 0x6f9440bc => 19
	i32 1885316902, ; 88: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 49
	i32 1900610850, ; 89: System.Resources.ResourceManager.dll => 0x71490522 => 2
	i32 1914624963, ; 90: System.IdentityModel.dll => 0x721edbc3 => 29
	i32 1919157823, ; 91: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 71
	i32 1986222447, ; 92: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 20
	i32 2011961780, ; 93: System.Buffers.dll => 0x77ec19b4 => 24
	i32 2019465201, ; 94: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 67
	i32 2040764568, ; 95: Microsoft.Identity.Client.Extensions.Msal.dll => 0x79a39898 => 14
	i32 2055257422, ; 96: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 65
	i32 2079903147, ; 97: System.Runtime.dll => 0x7bf8cdab => 37
	i32 2090596640, ; 98: System.Numerics.Vectors => 0x7c9bf920 => 35
	i32 2097448633, ; 99: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 62
	i32 2201231467, ; 100: System.Net.Http => 0x8334206b => 33
	i32 2217644978, ; 101: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 78
	i32 2244775296, ; 102: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 70
	i32 2253551641, ; 103: Microsoft.IdentityModel.Protocols => 0x86527819 => 18
	i32 2256548716, ; 104: Xamarin.AndroidX.MultiDex => 0x8680336c => 71
	i32 2279755925, ; 105: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 73
	i32 2315684594, ; 106: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 45
	i32 2369706906, ; 107: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 17
	i32 2471841756, ; 108: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 109: Java.Interop.dll => 0x93918882 => 9
	i32 2501346920, ; 110: System.Data.DataSetExtensions => 0x95178668 => 85
	i32 2505896520, ; 111: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 66
	i32 2562349572, ; 112: Microsoft.CSharp => 0x98ba5a04 => 11
	i32 2570120770, ; 113: System.Text.Encodings.Web => 0x9930ee42 => 40
	i32 2581819634, ; 114: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 79
	i32 2620871830, ; 115: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 56
	i32 2628210652, ; 116: System.Memory.Data => 0x9ca74fdc => 31
	i32 2640290731, ; 117: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 17
	i32 2640706905, ; 118: Azure.Core => 0x9d65fd59 => 7
	i32 2660759594, ; 119: System.Security.Cryptography.ProtectedData.dll => 0x9e97f82a => 93
	i32 2663698177, ; 120: System.Runtime.Loader => 0x9ec4cf01 => 38
	i32 2677098746, ; 121: Azure.Identity.dll => 0x9f9148fa => 8
	i32 2677798358, ; 122: Codeholic => 0x9f9bf5d6 => 0
	i32 2693849962, ; 123: System.IO.dll => 0xa090e36a => 101
	i32 2719963679, ; 124: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 95
	i32 2732626843, ; 125: Xamarin.AndroidX.Activity => 0xa2e0939b => 44
	i32 2737747696, ; 126: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 46
	i32 2740051746, ; 127: Microsoft.Identity.Client => 0xa351df22 => 13
	i32 2755098380, ; 128: Microsoft.SqlServer.Server.dll => 0xa437770c => 21
	i32 2778768386, ; 129: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 81
	i32 2810250172, ; 130: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 54
	i32 2819470561, ; 131: System.Xml.dll => 0xa80db4e1 => 42
	i32 2853208004, ; 132: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 81
	i32 2855708567, ; 133: Xamarin.AndroidX.Transition => 0xaa36a797 => 77
	i32 2867946736, ; 134: System.Security.Cryptography.ProtectedData => 0xaaf164f0 => 93
	i32 2901442782, ; 135: System.Reflection => 0xacf080de => 98
	i32 2903344695, ; 136: System.ComponentModel.Composition => 0xad0d8637 => 89
	i32 2905242038, ; 137: mscorlib.dll => 0xad2a79b6 => 23
	i32 2919462931, ; 138: System.Numerics.Vectors.dll => 0xae037813 => 35
	i32 2978675010, ; 139: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 59
	i32 3024354802, ; 140: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 63
	i32 3033605958, ; 141: System.Memory.Data.dll => 0xb4d12746 => 31
	i32 3084678329, ; 142: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 20
	i32 3111772706, ; 143: System.Runtime.Serialization => 0xb979e222 => 39
	i32 3124832203, ; 144: System.Threading.Tasks.Extensions => 0xba4127cb => 92
	i32 3147165239, ; 145: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 97
	i32 3204380047, ; 146: System.Data.dll => 0xbefef58f => 26
	i32 3211777861, ; 147: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 58
	i32 3220365878, ; 148: System.Threading => 0xbff2e236 => 5
	i32 3247949154, ; 149: Mono.Security => 0xc197c562 => 100
	i32 3253402803, ; 150: System.IdentityModel => 0xc1eafcb3 => 29
	i32 3258312781, ; 151: Xamarin.AndroidX.CardView => 0xc235e84d => 52
	i32 3265893370, ; 152: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 92
	i32 3267021929, ; 153: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 50
	i32 3312457198, ; 154: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 16
	i32 3317135071, ; 155: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 57
	i32 3317144872, ; 156: System.Data => 0xc5b79d28 => 26
	i32 3340431453, ; 157: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 49
	i32 3353484488, ; 158: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 62
	i32 3358260929, ; 159: System.Text.Json => 0xc82afec1 => 41
	i32 3362522851, ; 160: Xamarin.AndroidX.Core => 0xc86c06e3 => 55
	i32 3366347497, ; 161: Java.Interop => 0xc8a662e9 => 9
	i32 3374879918, ; 162: Microsoft.IdentityModel.Protocols.dll => 0xc92894ae => 18
	i32 3374999561, ; 163: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 73
	i32 3395150330, ; 164: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 36
	i32 3404865022, ; 165: System.ServiceModel.Internals => 0xcaf21dfe => 102
	i32 3429136800, ; 166: System.Xml => 0xcc6479a0 => 42
	i32 3430777524, ; 167: netstandard => 0xcc7d82b4 => 1
	i32 3476120550, ; 168: Mono.Android => 0xcf3163e6 => 22
	i32 3485117614, ; 169: System.Text.Json.dll => 0xcfbaacae => 41
	i32 3486566296, ; 170: System.Transactions => 0xcfd0c798 => 90
	i32 3501239056, ; 171: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 50
	i32 3509114376, ; 172: System.Xml.Linq => 0xd128d608 => 43
	i32 3515174580, ; 173: System.Security.dll => 0xd1854eb4 => 94
	i32 3545306353, ; 174: Microsoft.Data.SqlClient => 0xd35114f1 => 12
	i32 3561949811, ; 175: Azure.Core.dll => 0xd44f0a73 => 7
	i32 3567349600, ; 176: System.ComponentModel.Composition.dll => 0xd4a16f60 => 89
	i32 3627220390, ; 177: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 72
	i32 3641597786, ; 178: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 65
	i32 3672681054, ; 179: Mono.Android.dll => 0xdae8aa5e => 22
	i32 3676310014, ; 180: System.Web.Services.dll => 0xdb2009fe => 91
	i32 3682565725, ; 181: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 51
	i32 3689375977, ; 182: System.Drawing.Common => 0xdbe768e9 => 86
	i32 3700591436, ; 183: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 15
	i32 3718780102, ; 184: Xamarin.AndroidX.Annotation => 0xdda814c6 => 45
	i32 3748608112, ; 185: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3786282454, ; 186: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 53
	i32 3829621856, ; 187: System.Numerics.dll => 0xe4436460 => 34
	i32 3849253459, ; 188: System.Runtime.InteropServices.dll => 0xe56ef253 => 96
	i32 3885922214, ; 189: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 77
	i32 3896106733, ; 190: System.Collections.Concurrent.dll => 0xe839deed => 3
	i32 3896760992, ; 191: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 55
	i32 3920810846, ; 192: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 88
	i32 3921031405, ; 193: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 80
	i32 3945713374, ; 194: System.Data.DataSetExtensions.dll => 0xeb2ecede => 85
	i32 3955647286, ; 195: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 47
	i32 4025784931, ; 196: System.Memory => 0xeff49a63 => 32
	i32 4073602200, ; 197: System.Threading.dll => 0xf2ce3c98 => 5
	i32 4105002889, ; 198: Mono.Security.dll => 0xf4ad5f89 => 100
	i32 4151237749, ; 199: System.Core => 0xf76edc75 => 25
	i32 4182413190, ; 200: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 68
	i32 4185676441, ; 201: System.Security => 0xf97c5a99 => 94
	i32 4213026141, ; 202: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4260525087, ; 203: System.Buffers => 0xfdf2741f => 24
	i32 4263231520, ; 204: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 30
	i32 4292120959 ; 205: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 68
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [206 x i32] [
	i32 66, i32 84, i32 75, i32 96, i32 75, i32 53, i32 76, i32 51, ; 0..7
	i32 6, i32 63, i32 11, i32 91, i32 61, i32 44, i32 34, i32 21, ; 8..15
	i32 64, i32 32, i32 82, i32 4, i32 60, i32 23, i32 28, i32 61, ; 16..23
	i32 15, i32 70, i32 90, i32 99, i32 10, i32 95, i32 88, i32 57, ; 24..31
	i32 0, i32 40, i32 80, i32 48, i32 3, i32 43, i32 38, i32 87, ; 32..39
	i32 86, i32 72, i32 84, i32 64, i32 97, i32 4, i32 74, i32 47, ; 40..47
	i32 67, i32 14, i32 28, i32 12, i32 78, i32 48, i32 79, i32 59, ; 48..55
	i32 101, i32 102, i32 74, i32 2, i32 54, i32 36, i32 99, i32 30, ; 56..63
	i32 87, i32 46, i32 16, i32 8, i32 58, i32 39, i32 69, i32 19, ; 64..71
	i32 56, i32 33, i32 37, i32 83, i32 6, i32 98, i32 52, i32 76, ; 72..79
	i32 25, i32 60, i32 13, i32 10, i32 69, i32 83, i32 82, i32 19, ; 80..87
	i32 49, i32 2, i32 29, i32 71, i32 20, i32 24, i32 67, i32 14, ; 88..95
	i32 65, i32 37, i32 35, i32 62, i32 33, i32 78, i32 70, i32 18, ; 96..103
	i32 71, i32 73, i32 45, i32 17, i32 1, i32 9, i32 85, i32 66, ; 104..111
	i32 11, i32 40, i32 79, i32 56, i32 31, i32 17, i32 7, i32 93, ; 112..119
	i32 38, i32 8, i32 0, i32 101, i32 95, i32 44, i32 46, i32 13, ; 120..127
	i32 21, i32 81, i32 54, i32 42, i32 81, i32 77, i32 93, i32 98, ; 128..135
	i32 89, i32 23, i32 35, i32 59, i32 63, i32 31, i32 20, i32 39, ; 136..143
	i32 92, i32 97, i32 26, i32 58, i32 5, i32 100, i32 29, i32 52, ; 144..151
	i32 92, i32 50, i32 16, i32 57, i32 26, i32 49, i32 62, i32 41, ; 152..159
	i32 55, i32 9, i32 18, i32 73, i32 36, i32 102, i32 42, i32 1, ; 160..167
	i32 22, i32 41, i32 90, i32 50, i32 43, i32 94, i32 12, i32 7, ; 168..175
	i32 89, i32 72, i32 65, i32 22, i32 91, i32 51, i32 86, i32 15, ; 176..183
	i32 45, i32 27, i32 53, i32 34, i32 96, i32 77, i32 3, i32 55, ; 184..191
	i32 88, i32 80, i32 85, i32 47, i32 32, i32 5, i32 100, i32 25, ; 192..199
	i32 68, i32 94, i32 27, i32 24, i32 30, i32 68 ; 200..205
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
