import { Link } from "react-router-dom";
import "./UserSelectButton.css"

const UserSelectButton:React.FC<{userKey:string,isDHH:boolean|undefined,gender:string|undefined}>=({userKey,isDHH,gender})=>{
    return(
        <div id="userSelectButton">
            <Link to={"/"+userKey}>
                <button>
                    <h3>{userKey}</h3>
                    <p>{isDHH!=undefined?isDHH?"Deaf":"Hearing":"Firebase connection error"}</p>
                    <p>{gender!=undefined?gender==="m"?"Male":"Female":"Firebase connection error"}</p>
                </button>
            </Link>
        </div>
    )
};

export default UserSelectButton;