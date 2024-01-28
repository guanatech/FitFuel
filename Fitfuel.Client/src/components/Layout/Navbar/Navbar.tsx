import styles from "./navbar.module.scss";

const Navbar = () => {
  return (
    <div className={styles.root}>
      <ul className={styles.section}>
        <div className={styles.menu_logo}>
          <img src="/img/icons/menu-logo.svg" alt="logo" />
          <p>FITFUEL</p>
        </div>

        <li>
          <img src="/img/icons/home.svg" alt="home" />
          <p>Главная</p>
        </li>

        <li>
          <img src="/img/icons/dumbbell.svg" alt="dumbbell" />
          <p>Тренировка</p>
        </li>

        <li>
          <img src="/img/icons/apple.svg" alt="apple" />
          <p>Питание</p>
        </li>

        <li>
          <img src="/img/icons/learn-base.svg" alt="learnBase" />
          <p>База знаний</p>
        </li>
      </ul>

      <ul className={styles.section}>
        <li>
          <img src="/img/icons/statistics.svg" alt="statistics" />
          <p>Статистика</p>
        </li>
        <li>
          <img src="/img/icons/ai.svg" alt="ai" />
          <p>Trainer GPT</p>
        </li>
      </ul>

      <ul className={styles.section}></ul>
    </div>
  );
};

export default Navbar;
