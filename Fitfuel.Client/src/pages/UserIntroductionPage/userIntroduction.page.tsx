import IntroductionStepper from "../../components/Auth/IntroductionStepper/IntroductionStepper";
import styles from "./userIntroduction.page.module.scss";

const UserIntroductionPage = () => {
  return (
    <div className={styles.root}>
      <main>
        <IntroductionStepper />
      </main>
    </div>
  );
};

export default UserIntroductionPage;
