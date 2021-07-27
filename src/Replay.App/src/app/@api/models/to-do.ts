import { ToDoStatus } from "./to-do-status";

export type ToDo = {
    toDoId: string,
    type: string,
    name: string,
    description: string,
    status: ToDoStatus
};
