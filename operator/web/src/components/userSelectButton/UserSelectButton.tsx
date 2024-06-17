import { Link } from "react-router-dom";
import "./UserSelectButton.css"

const UserSelectButton:React.FC<{userIndex:number,isDHH:boolean}>=({userIndex,isDHH})=>{
    return(
        <div id="userSelectButton">
            <Link to={"/user"+String(userIndex)}>
                <button>
                    <h3>User {userIndex}</h3>
                    <p>is DHH : {String(isDHH)}</p>
                </button>
            </Link>
        </div>
    )
};

export default UserSelectButton;