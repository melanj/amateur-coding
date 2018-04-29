

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* at Sun Mar 01 20:57:57 2009
 */
/* Compiler settings for .\jstest.idl:
    Oicf, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __jstest_h_h__
#define __jstest_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __Ijstest_FWD_DEFINED__
#define __Ijstest_FWD_DEFINED__
typedef interface Ijstest Ijstest;
#endif 	/* __Ijstest_FWD_DEFINED__ */


#ifndef __jstest_FWD_DEFINED__
#define __jstest_FWD_DEFINED__

#ifdef __cplusplus
typedef class jstest jstest;
#else
typedef struct jstest jstest;
#endif /* __cplusplus */

#endif 	/* __jstest_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 


#ifndef __jstest_LIBRARY_DEFINED__
#define __jstest_LIBRARY_DEFINED__

/* library jstest */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_jstest;

#ifndef __Ijstest_DISPINTERFACE_DEFINED__
#define __Ijstest_DISPINTERFACE_DEFINED__

/* dispinterface Ijstest */
/* [uuid] */ 


EXTERN_C const IID DIID_Ijstest;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("C1C4D84F-CAB6-4387-985E-713880CB5786")
    Ijstest : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct IjstestVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            Ijstest * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            Ijstest * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            Ijstest * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            Ijstest * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            Ijstest * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            Ijstest * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            Ijstest * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } IjstestVtbl;

    interface Ijstest
    {
        CONST_VTBL struct IjstestVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define Ijstest_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define Ijstest_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define Ijstest_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define Ijstest_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define Ijstest_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define Ijstest_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define Ijstest_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* __Ijstest_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_jstest;

#ifdef __cplusplus

class DECLSPEC_UUID("68E2F675-62FF-46D4-A39A-3F72BD6DCF1B")
jstest;
#endif
#endif /* __jstest_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


