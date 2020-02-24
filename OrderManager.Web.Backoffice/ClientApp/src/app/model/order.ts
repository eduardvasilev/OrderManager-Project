import { OrderStatus } from "./orderStatus";

export class Order {
  id: number;
  creationDate: string;
  additionalData: string;
  statusId: OrderStatus;
}
