import "./User.css"
import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";

const User1:React.FC=()=>{
    return(
        <div className="user">
            <UserHeader userIndex={1} isDHH={true} />
            <div>
                <ScenarioButton scenario="シナリオ" />
            </div>
        </div>
    )
};

export default User1;