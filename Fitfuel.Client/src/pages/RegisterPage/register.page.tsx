import Register from "../../components/Auth/Register/Register";
import styles from "./register.page.module.scss";

const RegisterPage = () => {
  return (
    <div className={styles.root}>
      <main>
        <div className={styles.logo}>
          <img src="/img/icons/logo.svg" alt="logo" />
        </div>
        <Register />
      </main>
    </div>
  );
};

export default RegisterPage;
