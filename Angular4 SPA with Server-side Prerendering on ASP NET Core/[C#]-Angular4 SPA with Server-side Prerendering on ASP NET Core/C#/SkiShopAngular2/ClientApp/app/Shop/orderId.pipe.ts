import { Pipe } from '@angular/core';

@Pipe({
    name: 'orderId'
})
export class OrderIdPipe {
    transform(id: number): string {
        let text = id.toString();
        let length = text.length;
        for (let i = 0; i < 12 - length; i++) {
            text = `0${text}`;
        }
        return text;
    }
}
