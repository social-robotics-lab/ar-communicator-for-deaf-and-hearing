import { ReactNode, Dispatch, SetStateAction, createContext, useState } from "react";

type UsersInfoType={
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
    return(
        <UsersInfoContext.Provider value={{usersInfo,setUsersInfo}}>
            {children}
        </UsersInfoContext.Provider>
    )
}