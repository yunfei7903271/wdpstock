import React, { Component } from 'react';
import { Table, Popover } from 'antd';
import moment from 'moment';

export class Stock extends Component {

  constructor(props) {
    super(props);
    this.state = { reports: [], loading: true };

    fetch('api/stock/GetResearchReports')
      .then(response => response.json())
      .then(data => {
        //console.log("data", data);
        this.setState({ reports: data, loading: false });
      });
  }

  renderContent = (array) => {
    return <div>
      <p><span>{moment().format("YYYY")}:</span><span style={{ paddingLeft: '30px' }}>{this.renderSpaceChangeWord(array[0])}</span></p>
      <p><span>{moment().add(1, 'year').format("YYYY")}:</span><span style={{ paddingLeft: '30px' }}>{this.renderSpaceChangeWord(array[1])}</span></p>
      <p><span>{moment().add(2, 'year').format("YYYY")}:</span><span style={{ paddingLeft: '30px' }}>{this.renderSpaceChangeWord(array[2])}</span></p>
      <p><span>{moment().add(3, 'year').format("YYYY")}:</span><span style={{ paddingLeft: '30px' }}>{this.renderSpaceChangeWord(array[3])}</span></p>
    </div>
  }

  renderSpaceChangeWord = (text) => {
    return text !== "" ? text : "暂无数据"
  }


  renderForecastsTable = (reports) => {
    //console.log("reports", reports);
    const columns = [{
      title: '日期',
      dataIndex: 'dateTime',
      key: 'dateTime',
      width: '10%',
      render: (text, record) => {
        // console.log("record",record);
        return <span>
          {moment(record.dateTime).format("YYYYMMDD HH:mm:ss")}
        </span>
      }
    }, {
      title: '代码',
      dataIndex: 'secuFullCode',
      key: 'secuFullCode',
      width: '10%',
    },
    {

      title: '名称',
      dataIndex: 'secuName',
      key: 'secuName',
      width: '10%',
      //sorter: (a, b) => a.name === b.name,
    },
    {

      title: '出现次数',
      dataIndex: 'count',
      key: 'count',
      width: '10%',
      //sorter: (a, b) => a.name === b.name,
    },
    {

      title: '研报',
      dataIndex: 'title',
      key: 'title',
      render: (text, record) => (
        //console.log("record",record)
        <span>
          {/* <a href={`http://data.eastmoney.com/report/${record.DateTime}/${record.InfoCode}.html`}>{record.title}</a> */}
          <a href={`http://data.eastmoney.com/report/${moment(record.dateTime).format("YYYYMMDD")}/${record.infoCode}.html`} target="view_report">{record.title}</a>
        </span>
      ),
      width: '16%',
    },
    {

      title: '原文评级',
      dataIndex: 'rate',
      key: 'rate',
      width: '5%',
    },
    {

      title: '评级变动',
      dataIndex: 'change',
      key: 'change',
      width: '5%',
    },
    {

      title: '机构',
      dataIndex: 'insName',
      key: 'insName',
      width: '8%',
    },
    {

      title: '预测三年市盈率',
      dataIndex: 'syls',
      key: 'syls',
      render: (text, record) => {
        // console.log("record", record);
        //let { a, b, c } = { ...record.syls };
        return <Popover
          placement="leftTop"
          content={this.renderContent(record.syls)}
          title="三年预期PE">
          <span>
            悬停查看
          </span>
        </Popover>
      },
      width: '8%',
    },
    {

      title: '预测三年每股收益',
      dataIndex: 'sys',
      key: 'sys',
      render: (text, record) => {
        return <Popover
          placement="rightTop"
          content={this.renderContent(record.sys)}
          title="三年预期EPS">
          <span>
            悬停查看
          </span>
        </Popover>
      },
      width: '8%',
    },
    ];
    return (
      <div>
        <Table dataSource={reports} columns={columns} />
      </div>

    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : this.renderForecastsTable(this.state.reports);

    return (
      <div>
        {contents}
      </div>
    );
  }
}
