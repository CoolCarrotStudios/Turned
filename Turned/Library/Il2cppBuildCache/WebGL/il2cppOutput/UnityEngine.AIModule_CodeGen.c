﻿#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Boolean UnityEngine.AI.NavMeshAgent::SetDestination(UnityEngine.Vector3)
extern void NavMeshAgent_SetDestination_m244EFBCDB717576303DA711EE39572B865F43747 (void);
// 0x00000002 System.Void UnityEngine.AI.NavMeshAgent::ResetPath()
extern void NavMeshAgent_ResetPath_mEAB767048210D7EE16A3A765D41494D770D10A0C (void);
// 0x00000003 System.Void UnityEngine.AI.NavMeshAgent::set_speed(System.Single)
extern void NavMeshAgent_set_speed_mE71CB504B0CC1E977293722F9BA81B7060A99E14 (void);
// 0x00000004 System.Boolean UnityEngine.AI.NavMeshAgent::SetDestination_Injected(UnityEngine.Vector3&)
extern void NavMeshAgent_SetDestination_Injected_m41607AA111EE126BBBDCDDF76B7523B0BC369D9A (void);
// 0x00000005 UnityEngine.Vector3 UnityEngine.AI.NavMeshHit::get_position()
extern void NavMeshHit_get_position_m66845935ED76B2480F72EE6628EFD9D6BF35B39A (void);
// 0x00000006 System.Void UnityEngine.AI.NavMesh::Internal_CallOnNavMeshPreUpdate()
extern void NavMesh_Internal_CallOnNavMeshPreUpdate_m5C0CEF0AEF92B6BE0368AA5ABC02B4CCDEFA9AD5 (void);
// 0x00000007 System.Boolean UnityEngine.AI.NavMesh::SamplePosition(UnityEngine.Vector3,UnityEngine.AI.NavMeshHit&,System.Single,System.Int32)
extern void NavMesh_SamplePosition_m9675E148D95E1D92ED75DC608CAA33E75ABCA05E (void);
// 0x00000008 System.Int32 UnityEngine.AI.NavMesh::GetAreaFromName(System.String)
extern void NavMesh_GetAreaFromName_m93403FF30B1B83971D4B2DFA5BDC08789CB01F51 (void);
// 0x00000009 System.Boolean UnityEngine.AI.NavMesh::SamplePosition_Injected(UnityEngine.Vector3&,UnityEngine.AI.NavMeshHit&,System.Single,System.Int32)
extern void NavMesh_SamplePosition_Injected_m080B714E6E15722B909226ADC8176F66A51E418A (void);
// 0x0000000A System.Void UnityEngine.AI.NavMesh/OnNavMeshPreUpdate::.ctor(System.Object,System.IntPtr)
extern void OnNavMeshPreUpdate__ctor_mDBB85480C3EA968112EB3B356486B9C9FF387BD4 (void);
// 0x0000000B System.Void UnityEngine.AI.NavMesh/OnNavMeshPreUpdate::Invoke()
extern void OnNavMeshPreUpdate_Invoke_m8950FEDFD3E07B272ED469FD1911AA98C60FC28D (void);
// 0x0000000C System.IAsyncResult UnityEngine.AI.NavMesh/OnNavMeshPreUpdate::BeginInvoke(System.AsyncCallback,System.Object)
extern void OnNavMeshPreUpdate_BeginInvoke_m8B7FF1B745E38190A2B744775602508E77B291FA (void);
// 0x0000000D System.Void UnityEngine.AI.NavMesh/OnNavMeshPreUpdate::EndInvoke(System.IAsyncResult)
extern void OnNavMeshPreUpdate_EndInvoke_mA263F64ADF01540E24327DDB24BD334539B1B4D2 (void);
static Il2CppMethodPointer s_methodPointers[13] = 
{
	NavMeshAgent_SetDestination_m244EFBCDB717576303DA711EE39572B865F43747,
	NavMeshAgent_ResetPath_mEAB767048210D7EE16A3A765D41494D770D10A0C,
	NavMeshAgent_set_speed_mE71CB504B0CC1E977293722F9BA81B7060A99E14,
	NavMeshAgent_SetDestination_Injected_m41607AA111EE126BBBDCDDF76B7523B0BC369D9A,
	NavMeshHit_get_position_m66845935ED76B2480F72EE6628EFD9D6BF35B39A,
	NavMesh_Internal_CallOnNavMeshPreUpdate_m5C0CEF0AEF92B6BE0368AA5ABC02B4CCDEFA9AD5,
	NavMesh_SamplePosition_m9675E148D95E1D92ED75DC608CAA33E75ABCA05E,
	NavMesh_GetAreaFromName_m93403FF30B1B83971D4B2DFA5BDC08789CB01F51,
	NavMesh_SamplePosition_Injected_m080B714E6E15722B909226ADC8176F66A51E418A,
	OnNavMeshPreUpdate__ctor_mDBB85480C3EA968112EB3B356486B9C9FF387BD4,
	OnNavMeshPreUpdate_Invoke_m8950FEDFD3E07B272ED469FD1911AA98C60FC28D,
	OnNavMeshPreUpdate_BeginInvoke_m8B7FF1B745E38190A2B744775602508E77B291FA,
	OnNavMeshPreUpdate_EndInvoke_mA263F64ADF01540E24327DDB24BD334539B1B4D2,
};
extern void NavMeshHit_get_position_m66845935ED76B2480F72EE6628EFD9D6BF35B39A_AdjustorThunk (void);
static Il2CppTokenAdjustorThunkPair s_adjustorThunks[1] = 
{
	{ 0x06000005, NavMeshHit_get_position_m66845935ED76B2480F72EE6628EFD9D6BF35B39A_AdjustorThunk },
};
static const int32_t s_InvokerIndices[13] = 
{
	1189,
	1557,
	1327,
	1107,
	1555,
	2574,
	1903,
	2411,
	1875,
	849,
	1557,
	630,
	1309,
};
extern const CustomAttributesCacheGenerator g_UnityEngine_AIModule_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_UnityEngine_AIModule_CodeGenModule;
const Il2CppCodeGenModule g_UnityEngine_AIModule_CodeGenModule = 
{
	"UnityEngine.AIModule.dll",
	13,
	s_methodPointers,
	1,
	s_adjustorThunks,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	g_UnityEngine_AIModule_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
