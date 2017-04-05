import React  from 'react';

let Counter = React.createClass({
    getInitialState: function () {
        return { count: Number(this.props.start) }
    },
    incrementCount: function () {
        this.changeCount(+1)
    },
    decrementCount: function () {
        this.changeCount(-1)
    },
    changeCount: function(delta) {
        this.setState({
            count: this.state.count + delta
    });
    },
    render: function () {
        return <div>
            Count: {this.state.count}
            <button type="button" onClick={this.incrementCount}>+</button>
            <button type="button" onClick={this.decrementCount}>-</button>
        </div>
    }
});
export default Counter;