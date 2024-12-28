import { ref, set } from "firebase/database";
import { db } from "./firebaseConfig";

export const writeMessageData=(userKey:string,isDHH:boolean,gender:string,message:string)=>{
    set(ref(db,userKey+"/"),{
        isDHH:isDHH,
        gender:gender,
        message:message
    });
};