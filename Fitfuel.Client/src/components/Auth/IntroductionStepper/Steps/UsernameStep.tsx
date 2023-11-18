import Input from "../../../UI/Input/Input";
import styles from "../IntroductionStepper.module.scss";

const UsernameStep = () => {
  return (
    <div className={styles.usernameStep}>
      

      <h3 className={styles.username_label}>Как Вас зовут?</h3>

      <form>
        <div className={styles.input_container}>
          <Input type="text" placeholder="Имя" />
          <span className={styles.user_icon}>
            <img src="/img/icons/user.svg" alt="user-icon" />
          </span>
        </div>

        <h3 className={styles.gender_label}>Ваш пол?</h3>
        <ul>
          <li>
            <input type="radio" name="gender" id="cb" value="Male"/>
            <label htmlFor="cb">
              <img src="/img/male.svg" width={150} />
              <p>Мужчина</p>
            </label>
          </li>
          <li>
            <input type="radio" name="gender" id="cb2" value="Female"/>
            <label htmlFor="cb2">
              <img src="/img/female.svg" width={150} />
              <p>Женщина</p>
            </label>
          </li>
        </ul>
      </form>
    </div>
  );
};

export default UsernameStep;
