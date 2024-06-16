import UserSelectButton from "../components/userSelectButton/UserSelectButton";
import "./Home.css"

const Home:React.FC=()=>{
    return(
        <div id="home">
            <h2>ユーザーを選択してください</h2>
            <div className="buttons">
                <UserSelectButton userIndex={1} isDHH={true} />
                <UserSelectButton userIndex={2} isDHH={true} />
                <UserSelectButton userIndex={3} isDHH={true} />
            </div>
        </div>
    )
};

export default Home;