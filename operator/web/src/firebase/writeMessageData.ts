import { ref, set } from "firebase/database";
import { db } from "./firebaseConfig";

export const writeMessageData=(userKey:string,isDHH:boolean,message:string)=>{
    set(ref(db,userKey+"/"),{
        isDHH:isDHH,
        message:message
    });
};