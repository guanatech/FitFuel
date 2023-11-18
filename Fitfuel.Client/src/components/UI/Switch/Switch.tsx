import { FC } from "react";
import styles from "./switch.module.scss";

interface SwitchProps {
  switchOnText: string;
  switchOffText: string;
}

const Switch: FC<SwitchProps> = ({ switchOffText, switchOnText }) => {
  return (
    <label className={styles.root}>
      <input type="checkbox" />
      <span className={styles.switch}></span>
      <span
        className={styles.labels}
        switch-on={switchOnText ?? "ON"}
        switch-off={switchOffText ?? "OFF"}
      ></span>
    </label>
  );
};

export default Switch;
