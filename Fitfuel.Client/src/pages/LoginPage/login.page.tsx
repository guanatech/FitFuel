import { FC } from "react";
import styles from "./login.page.module.scss";
import Login from "../../components/Auth/Login/Login";

const LoginPage: FC = () => {
  return (
    <div className={styles.root}>
      <main>
        <div className={styles.logo}>
          <img src="/img/icons/logo.svg" alt="logo" />
        </div>
        <Login />
      </main>
    </div>
  );
};
export default LoginPage;
