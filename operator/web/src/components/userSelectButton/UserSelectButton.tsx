import { Link } from "react-router-dom";
import "./UserSelectButton.css"

const UserSelectButton:React.FC<{userKey:string,isDHH:boolean|undefined}>=({userKey,isDHH})=>{
    return(
        <div id="userSelectButton">
            <Link to={"/"+userKey}>
                <button>
                    <h3>{userKey}</h3>
                    <p>is DHH : {String(isDHH)}</p>
                </button>
            </Link>
        </div>
    )
};

export default UserSelectButton;