import http from 'k6/http';
import { sleep } from 'k6';

export default function() {
    http.get('http://localhost:5000/api/v1/Catalog');
    sleep(1);
}

