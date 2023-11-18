import { Link } from "react-router-dom";
import Button from "../../UI/Button/Button";
import Input from "../../UI/Input/Input";
import styles from "./register.module.scss";
import { useState } from "react";

const eyeIconUrl = "/img/icons/eye.svg";
const closeEyeIconUrl = "/img/icons/close-eye.svg";

const Register = () => {
  const [showPassword, setShowPassword] = useState(false);
  const handleClickShowPassword = () => setShowPassword(!showPassword);

  return (
    <div className={styles.root}>
      <h1 className={styles.title}>Приветствуем</h1>
      <p className={styles.subtitle}>
        В лучшем сервисе по ведению здорового образа жизни
      </p>

      <form>
        <Input type="text" placeholder="Адрес электронной почты" />

        <div className={styles.input_container}>
          <Input
            type={showPassword ? "text" : "password"}
            placeholder="Пароль"
          />
          <span
            className={styles.password_eye}
            onClick={handleClickShowPassword}
          >
            <img
              src={showPassword ? closeEyeIconUrl : eyeIconUrl}
              width="21px"
              alt="password-eye"
            />
          </span>
        </div>

        <div className={styles.input_container}>
          <Input
            type={showPassword ? "text" : "password"}
            placeholder="Повторите пароль"
          />
          <span
            className={styles.password_eye}
            onClick={handleClickShowPassword}
          >
            <img
              src={showPassword ? closeEyeIconUrl : eyeIconUrl}
              width="21px"
              alt="password-eye"
            />
          </span>
        </div>

        <div className={styles.rememberMe_checkbox}>
          <input type="checkbox" id="rememberMe" name="rememberMe" />
          <label htmlFor="rememberMe">Запомнить меня</label>
        </div>

        <div className={styles.signUp_btn}>
          <Button>Зарегистрироваться</Button>
          <p>
            Уже есть аккаунт? &nbsp;<Link to={"/auth/login"}>Войти</Link>
          </p>
        </div>
      </form>
    </div>
  );
};

export default Register;
