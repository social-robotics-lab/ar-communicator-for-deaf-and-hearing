import { ReactNode, Dispatch, SetStateAction, createContext, useState, useEffect } from "react";
import { db } from "../firebase/firebaseConfig";
import { ref, onValue } from "firebase/database";

export type UsersInfoType={
    user1:{isDHH:boolean},
    user2:{isDHH:boolean},
    user3:{isDHH:boolean}
}
export const UsersInfoContext=createContext(
    {} as {
		usersInfo: UsersInfoType;
		setUsersInfo: Dispatch<SetStateAction<UsersInfoType>>;
	});

type PropsType={
    children:ReactNode
}

export const UsersInfoProvider:React.FC<PropsType>=(props)=>{
    const {children}=props;
    const [usersInfo,setUsersInfo]=useState<UsersInfoType>(
        {
            user1:{isDHH:true},
            user2:{isDHH:true},
            user3:{isDHH:true}
        }
    );

    useEffect(()=>{
        try{
            const dataRef=ref(db,"/");
            return onValue(dataRef,(snapshot)=>{
                const data=snapshot.val();
                setUsersInfo(
                    {
                        user1:{isDHH:data.user1.isDHH},
                        user2:{isDHH:data.user2.isDHH},
                        user3:{isDHH:data.user3.isDHH}
                    });
            });
        }catch(error:any){
            console.log("firebase error: "+error);
        }
    },[]);

    return(
        <UsersInfoContext.Provider value={{usersInfo,setUsersInfo}}>
            {children}
        </UsersInfoContext.Provider>
    )
}