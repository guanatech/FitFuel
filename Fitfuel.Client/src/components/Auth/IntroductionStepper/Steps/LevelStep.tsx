import Option from "../../../UI/Option/Option";
import styles from "../IntroductionStepper.module.scss";

const LevelStep = () => {
  return (
    <div className={styles.levelStep}>
      <form>
        <h3 className={styles.level_label}>Ваш уровень подготовки?</h3>
        <div className={styles.row}>
          <Option group="level" text="Начинающий" value="Beginner" />
          <Option group="level" text="Средний" value="Middle" />
          <Option group="level" text="Продвинутый" value="Pro" />
        </div>

        <h3 className={styles.target_label}>Ваша основная цель?</h3>

        <ul>
          <li>
            <input
              type="radio"
              name="target"
              id="cb"
              value="ShapeMaintenance"
            />
            <label htmlFor="cb">
              <img src="/img/target_1.svg" alt="target" width={150} />
            </label>
          </li>
          <li>
            <input type="radio" name="target" id="cb2" value="WeightLoss" />
            <label htmlFor="cb2">
              <img src="/img/target_2.svg" alt="target" width={150} />
            </label>
          </li>
          <li>
            <input type="radio" name="target" id="cb3" value="WeightGain" />
            <label htmlFor="cb3">
              <img src="/img/target_3.svg" alt="target" width={150} />
            </label>
          </li>
        </ul>
        <div className={styles.row}>
          <div className={styles.caption_container}>
            <p className={styles.line}></p>
            <p className={styles.caption}>Набор массы</p>
          </div>
          <div className={styles.caption_container}>
            <p className={styles.line}></p>
            <p className={styles.caption}>Похудение</p>
          </div>
          <div className={styles.caption_container}>
            <p className={styles.line}></p>
            <p className={styles.caption}>Тонус мышц</p>
          </div>
        </div>
      </form>
    </div>
  );
};

export default LevelStep;
