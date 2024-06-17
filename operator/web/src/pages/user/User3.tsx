import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";

const User3:React.FC=()=>{
    return(
        <div className="user">
            <UserHeader userIndex={3} isDHH={true} />
            <div>
                <ScenarioButton scenario="シナリオ" />
            </div>
        </div>
    )
};

export default User3;