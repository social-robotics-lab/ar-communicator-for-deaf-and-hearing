import ScenarioButton from "../../components/ scenarioButton/ ScenarioButton";
import UserHeader from "../../components/userHeader/UserHeader";

const User2:React.FC=()=>{
    return(
        <div className="user">
            <UserHeader userIndex={2} isDHH={true} />
            <div>
                <ScenarioButton scenario="シナリオ" />
            </div>
        </div>
    )
};

export default User2;