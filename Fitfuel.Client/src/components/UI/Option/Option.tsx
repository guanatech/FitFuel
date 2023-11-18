import { FC } from "react";
import styles from "./option.module.scss";

interface OptionProps {
  value: string;
  group: string;
  text: string;
}

const Option: FC<OptionProps> = ({value, group, text}) => {
  return (
    <label className={styles.root}>
      <input type="radio" name={group} value={value} />
      <span>{text}</span>
    </label>
  );
};

export default Option;
