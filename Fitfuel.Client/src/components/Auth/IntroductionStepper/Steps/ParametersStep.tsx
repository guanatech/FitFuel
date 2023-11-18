import Input from "../../../UI/Input/Input";
import Switch from "../../../UI/Switch/Switch";
import styles from "../IntroductionStepper.module.scss";

const ParametersStep = () => {
  return (
    <div className={styles.parametersStep}>
      <form>
        <h3 className={styles.label}>Ваш рост</h3>
        <div className={styles.row}>
          <div className={styles.input_container}>
            <Input type="number" placeholder="Рост" />
          </div>
          <Switch switchOffText="Футы" switchOnText="СМ" />
        </div>

        <h3 className={styles.label}>Ваш текущий вес</h3>
        <div className={styles.row}>
          <div className={styles.input_container}>
            <Input type="number" placeholder="Вес" />
          </div>
          <Switch switchOffText="Фунты" switchOnText="КГ" />
        </div>

        <h3 className={styles.label}>Желаемый вес</h3>
        <div className={styles.row}>
          <div className={styles.input_container}>
            <Input type="number" placeholder="Вес" />
          </div>
          <Switch switchOffText="Фунты" switchOnText="КГ" />
        </div>
      </form>
    </div>
  );
};

export default ParametersStep;
