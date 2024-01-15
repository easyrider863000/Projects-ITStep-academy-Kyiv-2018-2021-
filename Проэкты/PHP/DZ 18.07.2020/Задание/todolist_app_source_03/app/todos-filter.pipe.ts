import { Pipe, PipeTransform } from '@angular/core';
import { Task } from './todos.service';

@Pipe({
  name: 'todosFilter'
})
export class TodosFilterPipe implements PipeTransform {

  transform(tasks: Task[], filter: string): Task[] {
    if (!filter.trim()) {
      return tasks;
    }

    return tasks.filter(task => {
      return (task.title.toLowerCase().indexOf(filter.toLowerCase()) !== -1);
    });
  }

}
