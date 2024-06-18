import { ref, set } from "firebase/database";
import { db } from "./firebaseConfig";
import { useContext } from "react";
import { UsersInfoContext } from "../providers/UsersInfoProvider";

export const writeMessageData=(userKey:string,isDHH:boolean,message:string)=>{
    set(ref(db,userKey+"/"),{
        isDHH:isDHH,
        message:message
    });
};